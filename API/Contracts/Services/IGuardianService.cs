using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IGuardianService
{
    Task<GuardianTableRowDTO> Create(GuardianForCreationDTO guardianDTO);
    Task<GuardianTableRowDTO> Update(Guid id, GuardianForUpdateDTO guardianDTO);
    Task Delete(Guid id);
    Task<GuardianDTO?> Retrieve(Guid id);
    Task<List<GuardianTableRowDTO>> RetrieveAll();
    Task<List<LabelValueDTO<Guid>>> RetrieveForList(string? text);
    Task<List<GuardianTableRowDTO>> RetrieveByNamesOrRut(string text);

}
