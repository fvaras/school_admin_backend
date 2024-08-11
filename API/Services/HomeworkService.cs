using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class HomeworkService : IHomeworkService
{
    private readonly ILoggerService _logger;
    private readonly IHomeworkRepository _homeworkRepository;
    private readonly IGuardianService _guardianService;
    private readonly IMapper _mapper;

    public HomeworkService(
        ILoggerService logger,
        IHomeworkRepository homeworkRepository,
        IGuardianService guardianService,
        IMapper mapper
        )
    {
        _logger = logger;
        _homeworkRepository = homeworkRepository;
        _guardianService = guardianService;
        _mapper = mapper;
    }

    public async Task<HomeworkTableRowDTO> Create(HomeworkForCreationDTO homeworkDTO)
    {
        Homework homework = _mapper.Map<Homework>(homeworkDTO);
        homework.CreatedAt = DateTimeOffset.Now;
        homework.UpdatedAt = DateTimeOffset.Now;
        await _homeworkRepository.Create(homework);
        return await RetrieveForTable(homework.Id);
    }

    public async Task<HomeworkTableRowDTO> Update(Guid id, HomeworkForUpdateDTO homeworkDTO)
    {
        Homework homework = await GetRecordAndCheckExistence(id);
        _mapper.Map(homeworkDTO, homework);
        homework.UpdatedAt = DateTimeOffset.Now;
        await _homeworkRepository.Update(homework);
        return await RetrieveForTable(homework.Id);
    }

    public async Task Delete(Guid id)
    {
        Homework homework = await GetRecordAndCheckExistence(id);
        await _homeworkRepository.Delete(homework);
    }

    public async Task<HomeworkDTO?> Retrieve(Guid id) => _mapper.Map<HomeworkDTO>(await _homeworkRepository.Retrieve(id));

    public async Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForGuardianMainTable(Guid guardianId, Guid studentId, Guid subjectId)
    {
        // Integrity guardianId/studentId
        await _guardianService.CheckRelationWithStudent(guardianId, studentId);

        // TODO: Validate integrity studentId/subjectId
        
        return _mapper.Map<List<HomeworkTableRowDTO>>(await _homeworkRepository.RetrieveBySubjectForMainTable(subjectId));
    }

    private async Task<Homework> GetRecordAndCheckExistence(Guid id)
    {
        Homework homework = await _homeworkRepository.Retrieve(id);
        if (homework is null)
            throw new EntityNotFoundException();
        return homework;
    }

    private async Task<HomeworkTableRowDTO?> RetrieveForTable(Guid id)
    {
        if (id == null) return null;
        var rows = await _homeworkRepository.RetrieveBySubjectForMainTable(id);
        if (rows == null || rows.Count == 0) return null;
        return _mapper.Map<HomeworkTableRowDTO>(rows.FirstOrDefault());
    }
}
