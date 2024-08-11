using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;
using static school_admin_api.Model.Planning;

namespace school_admin_api.Database;

public class PlanningRepository : RepositoryBase<Planning>, IPlanningRepository
{
    private readonly ApplicationDbContext _context;

    public PlanningRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Create(Planning planning) => await base.Create(planning);

    public async Task Update(Planning planning) => await base.Update(planning);

    public async Task Delete(Planning planning) => await base.Delete(planning);

    public async Task<Planning?> Retrieve(Guid id, bool trackChanges = false) =>
        await FindByCondition(p => p.Id == id, trackChanges)
                .FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Planning?> RetrieveWithTimeBlocks(Guid id, bool trackChanges = true) =>
        await FindByCondition(p => p.Id == id, trackChanges)
                .Include(p => p.PlanningTimeBlocks)
                .FirstOrDefaultAsync(m => m.Id == id);

    public async Task<List<Planning>> RetrieveAll() => await FindAll().ToListAsync();

    public async Task<List<PlanningTableRowDbDTO>> RetrieveForMainTable(Guid id, Guid teacherId) =>
        await FindAll(trackChanges: false)
            .Include(p => p.Subject)
                .ThenInclude(s => s.Grade)
            .Where(p => (p.Id == id || id == Guid.Empty) && (p.Subject.TeacherId == teacherId || teacherId == Guid.Empty))
            .Select(p => new PlanningTableRowDbDTO()
            {
                Id = p.Id,
                GradeId = p.Subject.Grade.Id,
                GradeName = p.Subject.Grade.Name,
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

    public async Task<List<LabelValueFromDB<Guid>>> RetrieveByGradeAndSubjectForList(Guid gradeId, Guid subjectId) =>
        await FindAll(trackChanges: false)
            .Include(p => p.Subject)
            .Where(p => p.Subject.GradeId == gradeId && p.SubjectId == subjectId && (p.StateId == (byte)PLANNING_STATES.ACTIVE || p.StateId == (byte)PLANNING_STATES.IN_CREATION))
            .Select(p => new LabelValueFromDB<Guid>()
            {
                Label = p.Title,
                Value = p.Id
            })
            .ToListAsync();

    public async Task<List<PlanningTableRowDbDTO>> RetrieveForTable(Guid subjectId) =>
        await FindAll(trackChanges: false)
            .Include(p => p.Subject)
            .Where(p => p.SubjectId == subjectId && (p.StateId == (byte)PLANNING_STATES.ACTIVE || p.StateId == (byte)PLANNING_STATES.IN_CREATION))
            .Select(p => new PlanningTableRowDbDTO()
            {
                Id = p.Id,
                GradeId = p.Subject.Grade.Id,
                GradeName = p.Subject.Grade.Name,
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

    public async Task<Planning?> RetrieveBySubjectTimeBlockAndDate(Guid subjectId, Guid timeBlockId, DateTimeOffset date) =>
        await FindAll(trackChanges: false)
            .Include(p => p.PlanningTimeBlocks)
            .Where(p => p.PlanningTimeBlocks.Any(t => t.TimeBlockId == timeBlockId && t.Date.Date == date.Date) && p.SubjectId == subjectId)
            .FirstOrDefaultAsync();

    // public async SetTimeblock(int timeblockId) => 
    //     await FindAll(trackChanges: true)
}