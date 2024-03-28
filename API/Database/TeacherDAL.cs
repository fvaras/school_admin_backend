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
                .FirstOrDefaultAsync();

    public async Task<Teacher?> RetrieveWithProfiles(int id, bool trackChanges = true) =>
        await FindByCondition(t => t.Id == id, trackChanges)
                .Include(t => t.User)
                    .ThenInclude(u => u.Profiles)
                .FirstOrDefaultAsync();

    public async Task<List<LabelValueFromDB<int>>> RetrieveForList() =>
        await FindByCondition(t => t.StateId == 1, false)
                .Select(t => new LabelValueFromDB<int>()
                {
                    Value = t.Id,
                    Label = $"TODO" // TODO: Get from User Entity // Label = $"{t.FirstName} {t.LastName}"
                })
                .ToListAsync();

    public async Task<List<Teacher>> RetrieveAll() =>
        await FindAll()
                .Include(t => t.User)
                .ToListAsync();
}
