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

    public async Task<int> Create(Student student)
    {
        await base.Create(student);
        return student.Id;
    }

    public async Task Update(Student student) => await base.Update(student);

    public async Task Delete(Student student) => await base.Delete(student);

    public async Task<Student?> Retrieve(int id, bool trackChanges = false) =>
        await FindByCondition(a => a.Id == id, trackChanges)
                .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<List<Student>> RetrieveAll() =>
        await FindAll()
                .Include(t => t.User)
                .ToListAsync();
}
