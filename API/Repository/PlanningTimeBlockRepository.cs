using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Repository;
using school_admin_api.Model;

namespace school_admin_api.Repository;

public class PlanningTimeBlockRepository : RepositoryBase<PlanningTimeBlock>, IPlanningTimeBlockRepository
{
    private readonly ApplicationDbContext _context;

    public PlanningTimeBlockRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<PlanningTimeBlock>> GetPlanningTimeBlocks(Guid timeBlockId, DateTimeOffset date) =>
        await FindAll(trackChanges: true)
            .Where(t => t.TimeBlockId == timeBlockId && t.Date.Date == date.Date)
            .ToListAsync();
}
