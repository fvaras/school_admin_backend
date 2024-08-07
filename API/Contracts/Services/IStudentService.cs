using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IStudentService
{
    Task<StudentTableRowDTO> Create(StudentForCreationDTO studentDTO);
    Task<StudentTableRowDTO> Update(Guid id, StudentForUpdateDTO studentDTO);
    Task Delete(Guid id);
    Task<StudentDTO?> Retrieve(Guid id);
    Task<List<StudentTableRowDTO>> RetrieveAll();
}
