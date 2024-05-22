using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class SubjectService : ISubjectService
{
    private readonly ISubjectDAL _subjectDAL;
    private readonly IMapper _mapper;

    public SubjectService(
        ISubjectDAL subjectDAL,
        IMapper mapper
        )
    {
        _subjectDAL = subjectDAL;
        _mapper = mapper;
    }

    public async Task<SubjectTableRowDTO> Create(SubjectForCreationDTO subjectDTO)
    {
        Subject subject = _mapper.Map<Subject>(subjectDTO);
        subject.CreatedAt = DateTime.Now;
        subject.UpdatedAt = DateTime.Now;
        await _subjectDAL.Create(subject);
        return await RetrieveForTable(subject.Id);
    }

    public async Task<SubjectTableRowDTO> Update(int id, SubjectForUpdateDTO subjectDTO)
    {
        Subject subject = await _subjectDAL.Retrieve(id) ?? throw new EntityNotFoundException();
        subject.UpdatedAt = DateTime.Now;
        _mapper.Map(subjectDTO, subject);
        await _subjectDAL.Update(subject);
        return await RetrieveForTable(subject.Id);
    }

    public async Task Delete(int id)
    {
        Subject subject = await _subjectDAL.Retrieve(id) ?? throw new EntityNotFoundException();
        await _subjectDAL.Delete(subject);
    }

    public async Task<SubjectDTO?> Retrieve(int id) => _mapper.Map<SubjectDTO>(await _subjectDAL.Retrieve(id));

    public async Task<List<SubjectTableRowDTO>> RetrieveAll() => _mapper.Map<List<SubjectTableRowDTO>>(await _subjectDAL.RetrieveAllForTable());

    private async Task<SubjectTableRowDTO?> RetrieveForTable(int id)
    {
        if (id == 0) return null;
        var rows = await _subjectDAL.RetrieveAllForTable(id);
        if (rows == null || rows.Count == 0) return null;
        return _mapper.Map<SubjectTableRowDTO>(rows.FirstOrDefault());
    }

    public async Task<List<LabelValueDTO<int>>> RetrieveByGrade(int gradeId) =>
        _mapper.Map<List<LabelValueDTO<int>>>(await _subjectDAL.RetrieveByGradeAndTeacherForList(gradeId, teacherId: 0));

    public async Task<List<LabelValueDTO<int>>> RetrieveByGradeAndTeacher(int gradeId, int teacherId) =>
        _mapper.Map<List<LabelValueDTO<int>>>(await _subjectDAL.RetrieveByGradeAndTeacherForList(gradeId, teacherId));
}
