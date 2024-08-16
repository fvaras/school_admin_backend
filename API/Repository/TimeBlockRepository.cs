using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Repository.DTO;
using school_admin_api.Model;

namespace school_admin_api.Repository;

public class TimeBlockRepository : RepositoryBase<TimeBlock>, ITimeBlockRepository
{
    private readonly ApplicationDbContext _context;

    public TimeBlockRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Create(TimeBlock timeBlock) => await base.Create(timeBlock);

    public async Task Update(TimeBlock timeBlock) => await base.Update(timeBlock);

    public async Task Delete(TimeBlock timeBlock) => await base.Delete(timeBlock);

    public async Task<TimeBlock?> Retrieve(Guid id, bool trackChanges = false) =>
        await FindByCondition(p => p.Id == id, trackChanges)
                .FirstOrDefaultAsync(m => m.Id == id);

    public async Task<List<TimeBlock>> RetrieveAll(Guid gradeId) =>
        await FindAll()
                // .Include(t => t.Subject) // TODO: Teacher can only view scoped plannings
                // .Where(t => t.GradeId == gradeId && t.Subject.StateId == (int)Subject.SUBJECT_STATES.ACTIVE && t.Subject.TeacherId == teacherId)
                .Where(t => t.GradeId == gradeId)
                .ToListAsync();

    public async Task<List<TimeBlockTableRowDbDTO>> RetrieveForMainTable(Guid id) =>
        await FindAll(trackChanges: false)
            .Where(t => t.Id == id || id == Guid.Empty)
            .Include(t => t.Grade)
            .Select(t => new TimeBlockTableRowDbDTO()
            {
                Id = t.Id,
                Year = t.Year,
                Day = t.Day,
                Start = t.Start,
                End = t.End,
                IsRecess = t.IsRecess,
                GradeId = t.GradeId,
                GradeName = t.Grade.Name
            })
            .ToListAsync();
}