using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Repository;
using school_admin_api.Model;

namespace school_admin_api.Repository;

public class ProfileRepository : RepositoryBase<Profile>, IProfileRepository
{
    private readonly ApplicationDbContext _context;

    public ProfileRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Profile?> Retrieve(Guid id, bool trackChanges = false) =>
        await FindByCondition(u => u.Id == id, trackChanges)
                .FirstOrDefaultAsync();

    public async Task<List<Profile>> RetrieveAll(bool trackChanges = false) => await FindAll(trackChanges).ToListAsync();
}
