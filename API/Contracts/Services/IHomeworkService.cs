using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IHomeworkService
{
    Task<Guid> Create(HomeworkForCreationDTO homeworkDTO, Guid teacherId);
    Task<HomeworkDTO> Update(Guid id, HomeworkForUpdateDTO homeworkDTO, Guid teacherId);
    Task Delete(Guid id, Guid teacherId);
    Task<HomeworkDTO?> Retrieve(Guid id);
    Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForTeacherMainTable(Guid teacherId, Guid subjectId);

    /********* Guardian *********/
    Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForGuardianMainTable(Guid guardianId, Guid studentId, Guid subjectId);
    /********* Guardian *********/

    /********* Student *********/
    Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForStudentMainTable(Guid studentId, Guid subjectId);
    /********* Student *********/
}
