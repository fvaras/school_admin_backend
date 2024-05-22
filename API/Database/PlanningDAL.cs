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

    public async Task<Planning?> RetrieveWithTimeBlocks(int id, bool trackChanges = true) =>
        await FindByCondition(p => p.Id == id, trackChanges)
                .Include(p => p.PlanningTimeBlocks)
                .FirstOrDefaultAsync(m => m.Id == id);

    public async Task<List<Planning>> RetrieveAll() => await FindAll().ToListAsync();

    public async Task<List<PlanningTableRowDbDTO>> RetrieveForMainTable(int id = 0, int teacherId = 0) =>
        await FindAll(trackChanges: false)
            .Include(p => p.Subject)
            .Where(p => (p.Id == id || id == 0) && (p.Subject.TeacherId == teacherId || teacherId == 0))
            .Select(p => new PlanningTableRowDbDTO()
            {
                Id = p.Id,
                SubjectId = p.SubjectId,
                SubjectName = p.Subject.Name,
                Title = p.Title,
                Description = p.Description,
                // ExpectedLearning = t.ExpectedLearning,
                // Contents = t.Contents,
                // Activities = t.Activities,
                // Resources = t.Resources,
                // EvaluationPlan = t.EvaluationPlan,
                EstimatedDuration = p.EstimatedDuration,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                // SubjectName = t.Subject.Name
            })
            .ToListAsync();

    public async Task<List<LabelValueFromDB<int>>> RetrieveByGradeAndSubject(int gradeId, int subjectId) =>
        await FindAll(trackChanges: false)
            .Include(p => p.Subject)
            .Where(p => p.Subject.GradeId == gradeId && p.SubjectId == subjectId)
            .Select(p => new LabelValueFromDB<int>()
            {
                Label = p.Title,
                Value = p.Id
            })
            .ToListAsync();

    public async Task<Planning?> RetrieveBySubjectTimeBlockAndDate(int subjectId, int timeBlockId, DateTime date) =>
        await FindAll(trackChanges: false)
            .Include(p => p.PlanningTimeBlocks)
            .Where(p => p.PlanningTimeBlocks.Any(t => t.TimeBlockId == timeBlockId && t.Date.Date == date.Date) && p.SubjectId == subjectId)
            .FirstOrDefaultAsync();

    // public async SetTimeblock(int timeblockId) => 
    //     await FindAll(trackChanges: true)
}