using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IStudentGuardianService
{
    Task<int> Create(StudentGuardianForCreationDTO studentGuardianDTO);
    Task Update(int id, StudentGuardianForUpdateDTO studentGuardianDTO);
    Task Delete(int id);
    Task<StudentGuardianDTO?> Retrieve(int id);
    Task<List<StudentGuardianDTO>> RetrieveAll();
}
