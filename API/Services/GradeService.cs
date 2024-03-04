using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class GradeService : IGradeService
{
    private readonly ILoggerService _logger;
    private readonly IGradeDAL _gradeDAL;
    private readonly IMapper _mapper;

    public GradeService(
        ILoggerService logger,
        IGradeDAL gradeDAL,
        IMapper mapper)
    {
        _logger = logger;
        _gradeDAL = gradeDAL;
        _mapper = mapper;
    }

    public async Task<int> Create(GradeForCreationDTO gradeDTO)
    {
        Grade grade = _mapper.Map<Grade>(gradeDTO);
        grade.CreatedAt = DateTime.Now;
        grade.UpdatedAt = DateTime.Now;
        return await _gradeDAL.Create(grade);
    }

    public async Task Update(int id, GradeForUpdateDTO gradeDTO)
    {
        Grade grade = await GetRecordAndCheckExistence(id);
        _mapper.Map(gradeDTO, grade);
        grade.UpdatedAt = DateTime.Now;
        await _gradeDAL.Update(grade);
    }

    public async Task Delete(int id)
    {
        Grade grade = await GetRecordAndCheckExistence(id);
        await _gradeDAL.Delete(grade);
    }

    public async Task<GradeDTO?> Retrieve(int id) =>
        _mapper.Map<GradeDTO>(await _gradeDAL.Retrieve(id));

    public async Task<List<GradeDTO>> RetrieveAll() =>
        _mapper.Map<List<GradeDTO>>(await _gradeDAL.RetrieveAll());

    private async Task<Grade> GetRecordAndCheckExistence(int id)
    {
        Grade grade = await _gradeDAL.Retrieve(id);
        if (grade == null)
            throw new EntityNotFoundException();
        return grade;
    }
}
