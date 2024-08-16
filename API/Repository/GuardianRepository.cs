using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Repository.DTO;
using school_admin_api.Model;
using static school_admin_api.Model.Guardian;
using static school_admin_api.Model.User;

namespace school_admin_api.Repository;

public class GuardianRepository : RepositoryBase<Guardian>, IGuardianRepository
{
    private readonly ApplicationDbContext _context;

    public GuardianRepository(ApplicationDbContext context) : base(context)
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

    public async Task<Guardian?> RetrieveByUserId(Guid userId, bool trackChanges = false) =>
        await FindByCondition(guardian => guardian.StateId == (byte)GUARDIAN_STATES.ACTIVE, trackChanges)
                .Include(p => p.User)
                .Where(guardian => guardian.User.Id == userId && guardian.User.StateId == (byte)USER_STATES.ACTIVE)
                .FirstOrDefaultAsync();

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

    public async Task<Guid> RetrieveIdByIdAndGuardian(Guid studentId, Guid guardianId) =>
        await FindByCondition(guardian => guardian.Id == guardianId, false)
                .Include(guardian => guardian.Students)
                .Where(guardian => guardian.Students.Any(student => student.Id == studentId))
                .SelectMany(guardian =>
                    guardian.Students.Select(student => student.Id)
                )
                .FirstOrDefaultAsync();
}
