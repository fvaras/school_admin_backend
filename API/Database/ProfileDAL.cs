using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class ProfileDAL : RepositoryBase<Profile>, IProfileDAL
{
    private readonly ApplicationDbContext _context;

    public ProfileDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Profile?> Retrieve(Guid id, bool trackChanges = false) =>
        await FindByCondition(u => u.Id == id, trackChanges)
                .FirstOrDefaultAsync();

    public async Task<List<Profile>> RetrieveAll(bool trackChanges = false) => await FindAll(trackChanges).ToListAsync();
}
