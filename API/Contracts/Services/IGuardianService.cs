using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IGuardianService
{
    Task<GuardianTableRowDTO> Create(GuardianForCreationDTO guardianDTO);
    Task<GuardianTableRowDTO> Update(int id, GuardianForUpdateDTO guardianDTO);
    Task Delete(int id);
    Task<GuardianDTO?> Retrieve(int id);
    Task<List<GuardianTableRowDTO>> RetrieveAll();
    Task<List<GuardianTableRowDTO>> RetrieveByNamesOrRut(string text);

}
