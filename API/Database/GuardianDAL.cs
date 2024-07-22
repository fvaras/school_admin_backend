using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class GuardianDAL : RepositoryBase<Guardian>, IGuardianDAL
{
    private readonly ApplicationDbContext _context;

    public GuardianDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Guardian guardian)
    {
        await base.Create(guardian);
        return guardian.Id; // Assuming Id is auto-generated
    }

    public async Task Update(Guardian guardian) => await base.Update(guardian);

    public async Task Delete(Guardian guardian) => await base.Delete(guardian);

    public async Task<Guardian?> Retrieve(Guid id, bool trackChanges = false) =>
        await FindByCondition(sg => sg.Id == id, trackChanges)
                .Include(p => p.User)
                .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Guardian?> RetrieveForMainTable(Guid id) =>
        await FindByCondition(a => a.Id == id, trackChanges: false)
                .Include(t => t.User)
                .FirstOrDefaultAsync();

    public async Task<List<Guardian>> RetrieveAll() =>
        await FindAll()
                .Where(t => t.User.StateId == (int)User.USER_STATES.ACTIVE)
                .Include(t => t.User)
                .ToListAsync();

    public async Task<List<LabelValueFromDB<Guid>>> RetrieveForList(string text) =>
            await FindByCondition(t => t.StateId == 1, false)
                    .Where(t =>
                        t.User.StateId == (int)User.USER_STATES.ACTIVE && t.StateId == (int)Teacher.TEACHER_STATES.ACTIVE
                        && (t.User.FirstName.ToLower().Contains(text.ToLower()) || t.User.LastName.ToLower().Contains(text.ToLower()))
                    )
                    .Include(t => t.User)
                    .Select(t => new LabelValueFromDB<Guid>()
                    {
                        Value = t.Id,
                        Label = $"{t.User.FirstName} {t.User.LastName}"
                    })
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
