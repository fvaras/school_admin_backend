using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class TeacherDAL : RepositoryBase<Teacher>, ITeacherDAL
{
    private readonly ApplicationDbContext _context;

    public TeacherDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> Create(Teacher teacher)
    {
        await base.Create(teacher);
        return teacher.Id;
    }

    public async Task Update(Teacher teacher) => await base.Update(teacher);

    public async Task Delete(Teacher teacher) => await base.Delete(teacher);

    public async Task<Teacher?> Retrieve(int id, bool trackChanges = false) =>
        await FindByCondition(t => t.Id == id, trackChanges)
                .Where(t => t.User.StateId == (int)User.USER_STATES.ACTIVE)
                .FirstOrDefaultAsync();

    public async Task<Teacher?> RetrieveWithUserAndProfiles(int id, bool trackChanges = true) =>
        await FindByCondition(t => t.Id == id, trackChanges)
                // .Where(t => t.User.StateId == (int)User.USER_STATES.ACTIVE)
                .Include(t => t.User)
                    .ThenInclude(u => u.Profiles)
                .FirstOrDefaultAsync();

    public async Task<Teacher?> RetrieveForMainTable(int id) =>
        await FindByCondition(a => a.Id == id, trackChanges: false)
            .Include(t => t.User)
            .FirstOrDefaultAsync();

    public async Task<List<LabelValueFromDB<int>>> RetrieveForList() =>
        await FindByCondition(t => t.StateId == 1, false)
                .Where(t => t.User.StateId == (int)User.USER_STATES.ACTIVE && t.StateId == (int)Teacher.TEACHER_STATES.ACTIVE)
                .Include(t => t.User)
                .Select(t => new LabelValueFromDB<int>()
                {
                    Value = t.Id,
                    Label = $"{t.User.FirstName} {t.User.LastName}"
                })
                .ToListAsync();

    public async Task<List<Teacher>> RetrieveAll() =>
        await FindAll()
                .Where(t => t.User.StateId == (int)Teacher.TEACHER_STATES.ACTIVE)
                .Include(t => t.User)
                .ToListAsync();

    public async Task<List<UserDerivedEntityDbDataForLists<int>>> RetrieveByNamesOrRut(string text) =>
        await FindAll()
                .Where(t => t.User.StateId == (int)User.USER_STATES.ACTIVE
                    && (
                        EF.Functions.Like(t.User.FirstName.ToLower(), $"%{text}%".ToLower()) ||
                        EF.Functions.Like(t.User.LastName.ToLower(), $"%{text}%".ToLower()) ||
                        EF.Functions.Like(t.User.Rut.ToLower(), $"%{text}%".ToLower())
                    ))
                .Include(t => t.User)
                .Select(t => new UserDerivedEntityDbDataForLists<int>()
                {
                    Id = t.Id,
                    Rut = t.User.Rut,
                    FirstName = t.User.FirstName,
                    LastName = t.User.LastName,
                })
                .ToListAsync();
}
