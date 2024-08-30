using school_admin_api.Model;

namespace school_admin_api.Contracts.Repository;

public interface IUserRepository
{
    Task<User> Create(User user, bool saveChanges = true);
    Task Update(User user);
    Task Delete(User user);
    Task<User?> Retrieve(Guid id, bool trackChanges = false);
    Task<User?> RetrieveByDNI(string rut, bool trackChanges = false);
    Task<User?> RetrieveByUserName(string userName, bool trackChanges = false);
    Task<User?> RetrieveByDNIWithProfiles(string rut, bool trackChanges = false);
    Task<List<User>> RetrieveAll();
    Task<User?> RetrieveByCredentials(string username, string password, Guid profileId);
}
