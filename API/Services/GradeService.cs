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
    private readonly IGradeRepository _gradeRepository;
    private readonly ITeacherDAL _teacherRepository;
    private readonly IGradeTeachersRepository _gradeTeachersRepository;
    private readonly IMapper _mapper;

    public GradeService(
        ILoggerService logger,
        IGradeRepository gradeRepository,
        ITeacherDAL teacherRepository,
        IGradeTeachersRepository gradeTeachersRepository,
        IMapper mapper)
    {
        _logger = logger;
        _gradeRepository = gradeRepository;
        _teacherRepository = teacherRepository;
        _gradeTeachersRepository = gradeTeachersRepository;
        _mapper = mapper;
    }

    public async Task<GradeDTO> Create(GradeForCreationDTO gradeDTO)
    {
        Grade grade = _mapper.Map<Grade>(gradeDTO);
        grade.CreatedAt = DateTimeOffset.UtcNow;
        grade.UpdatedAt = DateTimeOffset.UtcNow;

        foreach (Guid teacherId in gradeDTO.TeachersId)
            grade.GradeTeachers.Add(new()
            {
                Grade = grade,
                Teacher = await _teacherRepository.Retrieve(teacherId, trackChanges: true)
            });

        await _gradeRepository.Create(grade);
        return _mapper.Map<GradeDTO>(grade);
    }

    public async Task<GradeDTO> Update(Guid id, GradeForUpdateDTO gradeDTO)
    {
        Grade grade = await GetRecordAndCheckExistence(id, includeTeachers: false);

        _mapper.Map(gradeDTO, grade);
        grade.UpdatedAt = DateTimeOffset.UtcNow;

        // Retrieve current teacher associations for comparison
        List<Guid> currentTeacherIds = [];
        // currentTeacherIds = grade.GradeTeachers.Select(p => p.TeacherId).ToList();

        // // Determine teachers to remove
        // var teacherIdsToRemove = currentTeacherIds; // remove all //currentTeacherIds.Except(gradeDTO.TeachersId).ToList();
        // if (teacherIdsToRemove != null && teacherIdsToRemove.Count > 0)
        // {
        //     foreach (var teacherId in teacherIdsToRemove)
        //     {
        //         var teacherToRemove = grade.GradeTeachers.FirstOrDefault(t => t.TeacherId == teacherId);
        //         if (teacherToRemove != null)
        //             grade.GradeTeachers.Remove(teacherToRemove);
        //     }
        //     // await _gradeDAL.ClearTeacherAssociations(id);
        //     await _gradeDAL.Update(grade); // TODO: The relation isn't deleted. Maybe creating a new table for the relation and include a column for order as well (1st teacher, 2dn teacher, and son on)
        // }
        await _gradeTeachersRepository.ClearTeacherAssociations(gradeId: id, saveChanges: false);

        // Determine new teachers to add
        var newTeacherIds = gradeDTO.TeachersId.Except(currentTeacherIds).ToList();
        foreach (var newTeacherId in newTeacherIds)
        {
            var teacherToAdd = await _teacherRepository.Retrieve(newTeacherId, trackChanges: true);
            if (teacherToAdd != null)
                grade.GradeTeachers.Add(new()
                {
                    Grade = grade,
                    Teacher = teacherToAdd
                });
        }

        // Persist changes
        await _gradeRepository.Update(grade);
        return _mapper.Map<GradeDTO>(grade);
    }

    public async Task Delete(Guid id)
    {
        Grade grade = await GetRecordAndCheckExistence(id);

        // TODO: Delete relations Grades/Teachers
        await _gradeRepository.Delete(grade);
    }

    public async Task<GradeDTO?> Retrieve(Guid id) =>
        _mapper.Map<GradeDTO>(await _gradeRepository.Retrieve(id));

    public async Task<List<GradeDTO>> RetrieveAll() =>
        _mapper.Map<List<GradeDTO>>(await _gradeRepository.RetrieveAll());

    public async Task<List<LabelValueDTO<Guid>>> RetrieveForList() =>
        _mapper.Map<List<LabelValueDTO<Guid>>>(await _gradeRepository.RetrieveForList());

    /********* TEACHER *********/
    public async Task<List<LabelValueDTO<Guid>>> RetrieveByTeacherForList(Guid teacherId) =>
        _mapper.Map<List<LabelValueDTO<Guid>>>(await _gradeRepository.RetrieveByTeacherForList(teacherId));
    /********* TEACHER *********/

    private async Task<Grade> GetRecordAndCheckExistence(Guid id, bool includeTeachers = false)
    {
        Grade grade = null;
        if (includeTeachers)
            grade = await _gradeRepository.RetrieveWithTeachers(id);
        else
            grade = await _gradeRepository.Retrieve(id);

        if (grade == null)
            throw new EntityNotFoundException();
        return grade;
    }

    public async Task<List<Guid>> RetrieveTeachersId(Guid id) => await _gradeRepository.RetrieveTeachersId(id);
}
