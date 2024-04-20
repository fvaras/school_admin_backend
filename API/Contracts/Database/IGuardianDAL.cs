using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IGuardianDAL
{
    Task<int> Create(Guardian guardian);
    Task Update(Guardian guardian);
    Task Delete(Guardian guardian);
    Task<Guardian?> Retrieve(int id, bool trackChanges = false);
    Task<Guardian?> RetrieveForMainTable(int id);
    Task<List<Guardian>> RetrieveAll();

    Task<List<Guardian>> RetrieveByNamesOrRut(string text);
}
