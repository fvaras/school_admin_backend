using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class GuardianDAL : RepositoryBase<Guardian>, IGuardianDAL
{
    private readonly ApplicationDbContext _context;

    public GuardianDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> Create(Guardian guardian)
    {
        await base.Create(guardian);
        return guardian.Id; // Assuming Id is auto-generated
    }

    public async Task Update(Guardian guardian) => await base.Update(guardian);

    public async Task Delete(Guardian guardian) => await base.Delete(guardian);

    public async Task<Guardian?> Retrieve(int id, bool trackChanges = false) =>
        await FindByCondition(sg => sg.Id == id, trackChanges)
                .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Guardian?> RetrieveForMainTable(int id) =>
        await FindByCondition(a => a.Id == id, trackChanges: false)
                .Include(t => t.User)
                .FirstOrDefaultAsync();

    public async Task<List<Guardian>> RetrieveAll() =>
        await FindAll()
                .Where(t => t.User.StateId == (int)User.USER_STATES.ACTIVE)
                .Include(t => t.User)
                .ToListAsync();

    public async Task<List<Guardian>> RetrieveByNamesOrRut(string text) =>
        await FindAll()
                .Where(t => t.User.StateId == (int)User.USER_STATES.ACTIVE
                    && (
                        // t.User.FirstName.Contains("text", StringComparison.InvariantCultureIgnoreCase) ||
                        // t.User.LastName.Contains("text", StringComparison.InvariantCultureIgnoreCase))
                        EF.Functions.Like(t.User.FirstName.ToLower(), $"%{text}%".ToLower()) ||
                        EF.Functions.Like(t.User.LastName.ToLower(), $"%{text}%".ToLower())
                    ))
                .Include(t => t.User)
                .ToListAsync();
}
