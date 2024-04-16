using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IStudentGuardianService
{
    Task<StudentGuardianTableRowDTO> Create(StudentGuardianForCreationDTO studentGuardianDTO);
    Task<StudentGuardianTableRowDTO> Update(int id, StudentGuardianForUpdateDTO studentGuardianDTO);
    Task Delete(int id);
    Task<StudentGuardianDTO?> Retrieve(int id);
    Task<List<StudentGuardianTableRowDTO>> RetrieveAll();
}
