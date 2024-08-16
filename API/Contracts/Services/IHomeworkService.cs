using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IHomeworkService
{
    Task<Guid> Create(HomeworkForCreationDTO homeworkDTO, Guid teacherId);
    Task<HomeworkDTO> Update(Guid id, HomeworkForUpdateDTO homeworkDTO, Guid teacherId);
    Task Delete(Guid id, Guid teacherId);
    Task<HomeworkDTO?> Retrieve(Guid id);
    Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForTeacherMainTable(Guid teacherId, Guid subjectId);
    Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForGuardianMainTable(Guid guardianId, Guid studentId, Guid subjectId);
}
