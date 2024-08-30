using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Repository;
using school_admin_api.Model;

namespace school_admin_api.Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> Create(User user, bool saveChanges = true)
    {
        await base.Create(user, saveChanges);
        return user;
    }

    public async Task Update(User user) => await base.Update(user);

    public async Task Delete(User user) => await base.Delete(user);

    public async Task<User?> Retrieve(Guid id, bool trackChanges = false) =>
        await FindByCondition(u => u.Id == id, trackChanges)
                .FirstOrDefaultAsync();

    public async Task<User?> RetrieveByDNI(string rut, bool trackChanges = false) =>
        await FindByCondition(u => u.Rut == rut, trackChanges)
                .FirstOrDefaultAsync();

    public async Task<User?> RetrieveByUserName(string userName, bool trackChanges = false) =>
        await FindByCondition(u => u.UserName == userName, trackChanges)
                .FirstOrDefaultAsync();

    public async Task<User?> RetrieveByDNIWithProfiles(string rut, bool trackChanges = false) =>
        await FindByCondition(u => u.Rut == rut, trackChanges)
                .Include(u => u.UserProfiles)
                .ThenInclude(up => up.Profile)
                .FirstOrDefaultAsync();

    public async Task<List<User>> RetrieveAll() => await FindAll().ToListAsync();

    public async Task<User?> RetrieveByCredentials(string username, string password, Guid profileId)
        => await FindByCondition(u => u.UserName.Equals(username) && u.Password.Equals(password), trackChanges: false)
                .Include(u => u.UserProfiles)
                .ThenInclude(up => up.Profile)
                .Where(u => u.UserProfiles.Select(p => p.ProfileId).Contains(profileId)) // TODO: Filter by profileId
                .FirstOrDefaultAsync();
}
