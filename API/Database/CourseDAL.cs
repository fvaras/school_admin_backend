using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class CourseDAL : RepositoryBase<Course>, ICourseDAL
{
    private readonly ApplicationDbContext _context;

    public CourseDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> Create(Course course)
    {
        await base.Create(course);
        return course.Id; // Assuming Id is auto-generated
    }

    public async Task Update(Course course) => await base.Update(course);

    public async Task Delete(Course course) => await base.Delete(course);

    public async Task<Course?> Retrieve(int id, bool trackChanges = false) =>
        await FindByCondition(c => c.Id == id, trackChanges)
                .FirstOrDefaultAsync();

    public async Task<List<Course>> RetrieveAll() => await FindAll().ToListAsync();
}
