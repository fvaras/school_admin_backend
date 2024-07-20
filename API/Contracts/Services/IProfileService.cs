using school_admin_api.Model;

namespace school_admin_api.Contracts.Services;

public interface IProfileService
{
    Task<Profile?> Retrieve(Guid id, bool trackChanges = false);
}
