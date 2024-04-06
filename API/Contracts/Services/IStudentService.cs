using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IStudentService
{
    Task<StudentTableRowDTO> Create(StudentForCreationDTO studentDTO);
    Task<StudentTableRowDTO> Update(int id, StudentForUpdateDTO studentDTO);
    Task Delete(int id);
    Task<StudentDTO?> Retrieve(int id);
    Task<List<StudentTableRowDTO>> RetrieveAll();
}
