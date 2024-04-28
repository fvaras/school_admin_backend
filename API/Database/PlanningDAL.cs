using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class PlanningDAL : RepositoryBase<Planning>, IPlanningDAL
{
    private readonly ApplicationDbContext _context;

    public PlanningDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Create(Planning planning) => await base.Create(planning);

    public async Task Update(Planning planning) => await base.Update(planning);

    public async Task Delete(Planning planning) => await base.Delete(planning);

    public async Task<Planning?> Retrieve(int id, bool trackChanges = false) =>
        await FindByCondition(p => p.Id == id, trackChanges)
                .FirstOrDefaultAsync(m => m.Id == id);

    public async Task<List<Planning>> RetrieveAll() => await FindAll().ToListAsync();

    public async Task<List<PlanningTableRowDbDTO>> RetrieveForMainTable(int id = 0) =>
        await FindAll(trackChanges: false)
            .Where(t => t.Id == id || id == 0)
            .Include(t => t.Subject)
            .Select(t => new PlanningTableRowDbDTO()
            {
                Id = t.Id,
                SubjectId = t.SubjectId,
                Title = t.Title,
                Description = t.Description,
                // ExpectedLearning = t.ExpectedLearning,
                // Contents = t.Contents,
                // Activities = t.Activities,
                // Resources = t.Resources,
                // EvaluationPlan = t.EvaluationPlan,
                EstimatedDuration = t.EstimatedDuration,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                // SubjectName = t.Subject.Name
            })
            .ToListAsync();
}