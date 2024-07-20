using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class StudentDAL : RepositoryBase<Student>, IStudentDAL
{
    private readonly ApplicationDbContext _context;

    public StudentDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Student student)
    {
        await base.Create(student);
        return student.Id;
    }

    public async Task Update(Student student) => await base.Update(student);

    public async Task Delete(Student student) => await base.Delete(student);

    public async Task<Student?> Retrieve(Guid id, bool trackChanges = false) =>
        await FindByCondition(a => a.Id == id, trackChanges)
                .Include(p => p.User)
                .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Student?> RetrieveWithUserAndProfiles(Guid id, bool trackChanges = true) =>
        await FindByCondition(a => a.Id == id, trackChanges)
                .Include(t => t.User)
                    .ThenInclude(u => u.UserProfiles)
                .FirstOrDefaultAsync();

    public async Task<Student?> RetrieveWithGuardians(Guid id, bool trackChanges = true) =>
        await FindByCondition(a => a.Id == id, trackChanges)
                .Include(t => t.Guardians)
                .FirstOrDefaultAsync();

    public async Task<Student?> RetrieveForMainTable(Guid id) =>
        await FindByCondition(a => a.Id == id, trackChanges: false)
                .Include(p => p.Grade)
                .Include(t => t.User)
                .FirstOrDefaultAsync();

    public async Task<List<Student>> RetrieveAll() =>
        await FindAll()
                .Where(t => t.User.StateId == (int)User.USER_STATES.ACTIVE)
                .Include(t => t.User)
                .Include(t => t.Grade)
                .ToListAsync();

    public async Task<List<Guid>> RetrieveGuardiansId(Guid id) =>
        await FindByCondition(c => c.Id == id, trackChanges: false)
                .SelectMany(p => p.Guardians)
                .Select(p => p.Id)
                .ToListAsync();
}
