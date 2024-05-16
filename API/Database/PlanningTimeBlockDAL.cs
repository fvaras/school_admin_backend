using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class PlanningTimeBlockDAL : RepositoryBase<PlanningTimeBlock>, IPlanningTimeBlockDAL
{
    private readonly ApplicationDbContext _context;

    public PlanningTimeBlockDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<PlanningTimeBlock>> GetPlanningTimeBlocks(int timeBlockId, DateTime date) =>
        await FindAll(trackChanges: true)
            .Where(t => t.TimeBlockId == timeBlockId && t.Date.Date == date.Date)
            .ToListAsync();
}
