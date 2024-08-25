using AutoMapper;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class HomeworkService : IHomeworkService
{
    private readonly ILoggerService _logger;
    private readonly IHomeworkRepository _homeworkRepository;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IGuardianService _guardianService;
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;

    public HomeworkService(
        ILoggerService logger,
        IHomeworkRepository homeworkRepository,
        ISubjectRepository subjectRepository,
        IGuardianService guardianService,
        IStudentService studentService,
        IMapper mapper
        )
    {
        _logger = logger;
        _homeworkRepository = homeworkRepository;
        _subjectRepository = subjectRepository;
        _guardianService = guardianService;
        _studentService = studentService;
        _mapper = mapper;
    }

    public async Task<Guid> Create(HomeworkForCreationDTO homeworkDTO, Guid teacherId)
    {
        // Validate Subject/Teacher Integrity
        await ValidateIntegrity(subjectId: homeworkDTO.SubjectId, teacherId: teacherId);

        Homework homework = _mapper.Map<Homework>(homeworkDTO);
        homework.CreatedAt = DateTimeOffset.Now;
        homework.UpdatedAt = DateTimeOffset.Now;
        await _homeworkRepository.Create(homework);
        return homework.Id;
    }

    public async Task<HomeworkDTO> Update(Guid id, HomeworkForUpdateDTO homeworkDTO, Guid teacherId)
    {
        // Validate Subject/Teacher Integrity
        await ValidateIntegrity(subjectId: homeworkDTO.SubjectId, teacherId: teacherId);

        Homework homework = await GetRecordAndCheckExistence(id);
        _mapper.Map(homeworkDTO, homework);
        homework.UpdatedAt = DateTimeOffset.Now;
        await _homeworkRepository.Update(homework);
        return await Retrieve(homework.Id);
    }

    public async Task Delete(Guid id, Guid teacherId)
    {
        // Validate Subject/Teacher Integrity
        await ValidateIntegrity(subjectId: id, teacherId: teacherId);

        Homework homework = await GetRecordAndCheckExistence(id);
        await _homeworkRepository.Delete(homework);
    }

    public async Task<HomeworkDTO?> Retrieve(Guid id) => _mapper.Map<HomeworkDTO>(await _homeworkRepository.Retrieve(id));

    public async Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForTeacherMainTable(Guid teacherId, Guid subjectId)
    {
        // Validate Subject/Teacher Integrity
        await ValidateIntegrity(subjectId: subjectId, teacherId: teacherId);

        return _mapper.Map<List<HomeworkTableRowDTO>>(await _homeworkRepository.RetrieveBySubjectForMainTable(subjectId));
    }

    /********* Guardian *********/
    public async Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForGuardianMainTable(Guid guardianId, Guid studentId, Guid subjectId)
    {
        // Integrity guardianId/studentId
        await _guardianService.ValidateIntegrityWithStudent(guardianId: guardianId, studentId: studentId);

        // TODO: Validate integrity studentId/subjectId

        return _mapper.Map<List<HomeworkTableRowDTO>>(await _homeworkRepository.RetrieveBySubjectForMainTable(subjectId));
    }
    /********* Guardian *********/

    /********* Student *********/
    public async Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForStudentMainTable(Guid studentId, Guid subjectId)
    {
        // // TODO: Validate integrity studentId/subjectId
        // var student = await _studentService.Retrieve(studentId);

        return _mapper.Map<List<HomeworkTableRowDTO>>(await _homeworkRepository.RetrieveBySubjectForMainTable(subjectId));
    }
    /********* Student *********/


    private async Task ValidateIntegrity(Guid subjectId, Guid teacherId)
    {
        var subjectDbId = await _subjectRepository.RetrieveIdByIdAndTeacher(
                    subjectId: subjectId,
                    teacherId: teacherId);
        if (subjectDbId == null)
            throw new InconsistentDataException();
    }

    private async Task<Homework> GetRecordAndCheckExistence(Guid id)
    {
        Homework homework = await _homeworkRepository.Retrieve(id);
        if (homework is null)
            throw new EntityNotFoundException();
        return homework;
    }
}
