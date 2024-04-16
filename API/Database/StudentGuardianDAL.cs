using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class StudentGuardianDAL : RepositoryBase<StudentGuardian>, IStudentGuardianDAL
{
    private readonly ApplicationDbContext _context;

    public StudentGuardianDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> Create(StudentGuardian studentGuardian)
    {
        await base.Create(studentGuardian);
        return studentGuardian.Id; // Assuming Id is auto-generated
    }

    public async Task Update(StudentGuardian studentGuardian) => await base.Update(studentGuardian);

    public async Task Delete(StudentGuardian studentGuardian) => await base.Delete(studentGuardian);

    public async Task<StudentGuardian?> Retrieve(int id, bool trackChanges = false) =>
        await FindByCondition(sg => sg.Id == id, trackChanges)
                .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<StudentGuardian?> RetrieveForMainTable(int id) =>
        await FindByCondition(a => a.Id == id, trackChanges: false)
                .Include(t => t.User)
                .FirstOrDefaultAsync();

    public async Task<List<StudentGuardian>> RetrieveAll() => 
        await FindAll()
                .Where(t => t.User.StateId == (int)User.USER_STATES.ACTIVE)
                .Include(t => t.User)
                .ToListAsync();
}
