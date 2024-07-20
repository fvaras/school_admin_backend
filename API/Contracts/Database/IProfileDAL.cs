using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IProfileDAL
{
    Task<Profile?> Retrieve(Guid id, bool trackChanges = false);
    Task<List<Profile>> RetrieveAll(bool trackChanges = false);
}