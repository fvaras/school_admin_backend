using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class GradeDAL : RepositoryBase<Grade>, IGradeDAL
{
    private readonly ApplicationDbContext _context;

    public GradeDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> Create(Grade grade)
    {
        await base.Create(grade);
        return grade.Id; // Assuming Id is auto-generated
    }

    public async Task Update(Grade grade) => await base.Update(grade);

    public async Task Delete(Grade grade) => await base.Delete(grade);

    public async Task<Grade?> Retrieve(int id, bool trackChanges = false) =>
        await FindByCondition(c => c.Id == id, trackChanges)
                // .Include(g => g.Teachers)
                .FirstOrDefaultAsync();

    public async Task<List<Grade>> RetrieveAll() => await FindAll().ToListAsync();

    public async Task<List<LabelValueFromDB<int>>> RetrieveForList() =>
        await FindByCondition(g => g.Active == true, false)
                .Select(g => new LabelValueFromDB<int>()
                {
                    Value = g.Id,
                    Label = $"{g.Name}"
                })
                .ToListAsync();

    public async Task<List<int>> RetrieveTeachersId(int id)
    {
        return await FindByCondition(c => c.Id == id, trackChanges: false)
            .SelectMany(p => p.Teachers)
            .Select(p => p.Id)
            .ToListAsync();
    }
}
