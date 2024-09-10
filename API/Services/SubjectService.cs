using AutoMapper;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IGradeRepository _gradeRepository;
    private readonly IMapper _mapper;

    public SubjectService(
        ISubjectRepository subjectRepository,
        IStudentRepository studentRepository,
        IGradeRepository gradeRepository,
        IMapper mapper
        )
    {
        _subjectRepository = subjectRepository;
        _studentRepository = studentRepository;
        _gradeRepository = gradeRepository;
        _mapper = mapper;
    }

    public async Task<SubjectTableRowDTO> Create(SubjectForCreationDTO subjectDTO)
    {
        Subject subject = _mapper.Map<Subject>(subjectDTO);
        subject.CreatedAt = DateTimeOffset.UtcNow;
        subject.UpdatedAt = DateTimeOffset.UtcNow;
        await _subjectRepository.Create(subject);
        return await RetrieveForTable(subject.Id);
    }

    public async Task<SubjectTableRowDTO> Update(Guid id, SubjectForUpdateDTO subjectDTO)
    {
        Subject subject = await _subjectRepository.Retrieve(id) ?? throw new EntityNotFoundException();
        subject.UpdatedAt = DateTimeOffset.UtcNow;
        _mapper.Map(subjectDTO, subject);
        await _subjectRepository.Update(subject);
        return await RetrieveForTable(subject.Id);
    }

    public async Task Delete(Guid id)
    {
        Subject subject = await _subjectRepository.Retrieve(id) ?? throw new EntityNotFoundException();
        await _subjectRepository.Delete(subject);
    }

    public async Task<SubjectDTO?> Retrieve(Guid id) => _mapper.Map<SubjectDTO>(await _subjectRepository.Retrieve(id));

    public async Task<List<SubjectTableRowDTO>> RetrieveAll() => _mapper.Map<List<SubjectTableRowDTO>>(await _subjectRepository.RetrieveAllForTable(Guid.Empty));

    private async Task<SubjectTableRowDTO?> RetrieveForTable(Guid id)
    {
        if (id == Guid.Empty) return null;
        var rows = await _subjectRepository.RetrieveAllForTable(id);
        if (rows == null || rows.Count == 0) return null;
        return _mapper.Map<SubjectTableRowDTO>(rows.FirstOrDefault());
    }

    // public async Task<List<LabelValueDTO<Guid>>> RetrieveByGrade(Guid gradeId) =>
    //     _mapper.Map<List<LabelValueDTO<Guid>>>(await _subjectRepository.RetrieveByGradeAndTeacherForList(gradeId, teacherId: 0));

    /********* Teacher *********/
    public async Task<List<PKFKPair<Guid, Guid>>> RetrieveWithGradeByTeacherForList(Guid teacherId) =>
        _mapper.Map<List<PKFKPair<Guid, Guid>>>(await _subjectRepository.RetrieveWithGradeByTeacherForList(teacherId));

    public async Task<List<LabelValueDTO<Guid>>> RetrieveByMainTeacherForList(Guid teacherId, Guid gradeId)
    {
        // Get Grade by Teacher
        var grade = await _gradeRepository.RetrieveWithTeachers(gradeId);//RetrieveByTeacherForList
        if (!grade.GradeTeachers.Any(teacher => teacher.TeacherId == teacherId))
            throw new InconsistentDataException("Current teacher isn't the main teacher");

        var list = await _subjectRepository.RetrieveByGrade(grade.Id);
        return _mapper.Map<List<LabelValueDTO<Guid>>>(list);
    }
    /********* Teacher *********/

    /********* Guardian *********/
    public async Task<List<LabelValueDTO<Guid>>> RetrieveForListByGuardianAndStudent(Guid guardianId, Guid studentId)
    {
        Student student = await _studentRepository.RetrieveWithGuardians(studentId, false);
        if (student is null)
            throw new EntityNotFoundException();

        if (!student.Guardians.Any(guardian => guardian.Id == guardianId))
            throw new InconsistentDataException("Records not related");

        if (student.GradeId == null)
            return [];

        return _mapper.Map<List<LabelValueDTO<Guid>>>(await _subjectRepository.RetrieveByGrade((Guid)student.GradeId));
    }
    /********* Guardian *********/

    /********* Student *********/
    public async Task<List<LabelValueDTO<Guid>>> RetrieveForListByStudent(Guid studentId)
    {
        Student student = await _studentRepository.Retrieve(studentId, false);
        if (student is null)
            throw new EntityNotFoundException();

        return _mapper.Map<List<LabelValueDTO<Guid>>>(await _subjectRepository.RetrieveByGrade((Guid)student.GradeId));
    }
    /********* Student *********/
}
