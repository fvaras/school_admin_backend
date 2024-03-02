using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IStudentService
{
    Task<int> Create(StudentForCreationDTO studentDTO);
    Task Update(int id, StudentForUpdateDTO studentDTO);
    Task Delete(int id);
    Task<StudentDTO?> Retrieve(int id);
    Task<List<StudentDTO>> RetrieveAll();
}
