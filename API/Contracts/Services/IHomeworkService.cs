using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IHomeworkService
{
    Task<HomeworkTableRowDTO> Create(HomeworkForCreationDTO homeworkDTO);
    Task<HomeworkTableRowDTO> Update(Guid id, HomeworkForUpdateDTO homeworkDTO);
    Task Delete(Guid id);
    Task<HomeworkDTO?> Retrieve(Guid id);
    Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForGuardianMainTable(Guid guardianId, Guid studentId, Guid subjectId);
}
