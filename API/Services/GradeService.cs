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
    private readonly ITeacherDAL _teacherDAL;
    private readonly IMapper _mapper;

    public GradeService(
        ILoggerService logger,
        IGradeDAL gradeDAL,
        ITeacherDAL teacherDAL,
        IMapper mapper)
    {
        _logger = logger;
        _gradeDAL = gradeDAL;
        _teacherDAL = teacherDAL;
        _mapper = mapper;
    }

    public async Task<GradeDTO> Create(GradeForCreationDTO gradeDTO)
    {
        Grade grade = _mapper.Map<Grade>(gradeDTO);
        grade.CreatedAt = DateTime.Now;
        grade.UpdatedAt = DateTime.Now;

        foreach (int teacherId in gradeDTO.TeachersId)
            grade.Teachers.Add(await _teacherDAL.Retrieve(teacherId, trackChanges: true));

        await _gradeDAL.Create(grade);
        return _mapper.Map<GradeDTO>(grade);
    }

    public async Task<GradeDTO> Update(int id, GradeForUpdateDTO gradeDTO)
    {
        Grade grade = await GetRecordAndCheckExistence(id);

        _mapper.Map(gradeDTO, grade);
        grade.UpdatedAt = DateTime.Now;

        // Retrieve current teacher associations for comparison
        var currentTeacherIds = await _gradeDAL.RetrieveTeachersId(id);

        // Determine teachers to remove
        var teacherIdsToRemove = currentTeacherIds.Except(gradeDTO.TeachersId).ToList();
        foreach (var teacherId in teacherIdsToRemove)
        {
            var teacherToRemove = grade.Teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacherToRemove != null)
                grade.Teachers.Remove(teacherToRemove);
        }

        // Determine new teachers to add
        var newTeacherIds = gradeDTO.TeachersId.Except(currentTeacherIds).ToList();
        foreach (var newTeacherId in newTeacherIds)
        {
            var teacherToAdd = await _teacherDAL.Retrieve(newTeacherId, trackChanges: true);
            if (teacherToAdd != null)
                grade.Teachers.Add(teacherToAdd);
        }

        // Persist changes
        await _gradeDAL.Update(grade);
        return _mapper.Map<GradeDTO>(grade);
    }

    public async Task Delete(int id)
    {
        Grade grade = await GetRecordAndCheckExistence(id);

        // TODO: Delete relations Grades/Teachers
        await _gradeDAL.Delete(grade);
    }

    public async Task<GradeDTO?> Retrieve(int id) =>
        _mapper.Map<GradeDTO>(await _gradeDAL.Retrieve(id));

    public async Task<List<GradeDTO>> RetrieveAll() =>
        _mapper.Map<List<GradeDTO>>(await _gradeDAL.RetrieveAll());

    public async Task<List<LabelValueDTO<int>>> RetrieveForList() =>
        _mapper.Map<List<LabelValueDTO<int>>>(await _gradeDAL.RetrieveForList());

    private async Task<Grade> GetRecordAndCheckExistence(int id)
    {
        Grade grade = await _gradeDAL.Retrieve(id);
        if (grade == null)
            throw new EntityNotFoundException();
        return grade;
    }

    public async Task<List<int>> RetrieveTeachersId(int id) => await _gradeDAL.RetrieveTeachersId(id);
}
