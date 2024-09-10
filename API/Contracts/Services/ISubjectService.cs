using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ISubjectService
{
    Task<SubjectTableRowDTO> Create(SubjectForCreationDTO subjectDTO);
    Task<SubjectTableRowDTO> Update(Guid id, SubjectForUpdateDTO subjectDTO);
    Task Delete(Guid id);
    Task<SubjectDTO?> Retrieve(Guid id);
    Task<List<SubjectTableRowDTO>> RetrieveAll();
    // Task<List<LabelValueDTO<Guid>>> RetrieveByGrade(Guid gradeId);

    /********* Teacher *********/
    Task<List<PKFKPair<Guid, Guid>>> RetrieveWithGradeByTeacherForList(Guid teacherId);
    Task<List<LabelValueDTO<Guid>>> RetrieveByMainTeacherForList(Guid teacherId, Guid gradeId);
    /********* Teacher *********/

    /********* Guardian *********/
    Task<List<LabelValueDTO<Guid>>> RetrieveForListByGuardianAndStudent(Guid guardianId, Guid studentId);
    /********* Guardian *********/

    /********* Student *********/
    Task<List<LabelValueDTO<Guid>>> RetrieveForListByStudent(Guid studentId);
    /********* Student *********/
}
