using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class UserDAL : RepositoryBase<User>, IUserDAL
{
    private readonly ApplicationDbContext _context;

    public UserDAL(ApplicationDbContext context) : base(context)
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

    public async Task<User?> Retrieve(int id, bool trackChanges = false) =>
        await FindByCondition(u => u.Id == id, trackChanges)
                .FirstOrDefaultAsync();

    public async Task<User?> RetrieveByDNI(string rut, bool trackChanges = false) =>
        await FindByCondition(u => u.Rut == rut, trackChanges)
                .FirstOrDefaultAsync();

    public async Task<User?> RetrieveByDNIWithProfiles(string rut, bool trackChanges = false) =>
        await FindByCondition(u => u.Rut == rut, trackChanges)
                .Include(t => t.Profiles)
                .FirstOrDefaultAsync();

    public async Task<List<User>> RetrieveAll() => await FindAll().ToListAsync();

    public async Task<User?> RetrieveByCredentials(string username, string password)
        => await FindByCondition(
                u => u.UserName.Equals(username)
                && u.Password.Equals(password), trackChanges: false)
                .FirstOrDefaultAsync();
}
