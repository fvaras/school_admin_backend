using school_admin_api.Contracts.Repository.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Repository;

public interface IGuardianRepository
{
    Task<Guid> Create(Guardian guardian);
    Task Update(Guardian guardian);
    Task Delete(Guardian guardian);
    Task<Guardian?> Retrieve(Guid id, bool trackChanges = false);
    Task<Guardian?> RetrieveByUserId(Guid userId, bool trackChanges = false);
    Task<Guardian?> RetrieveForMainTable(Guid id);

    Task<List<LabelValueFromDB<Guid>>> RetrieveForList(string text);
    Task<List<Guardian>> RetrieveAll();

    Task<List<Guardian>> RetrieveByNamesOrRut(string text);

    Task<Guid> RetrieveIdByIdAndGuardian(Guid studentId, Guid guardianId);
}
