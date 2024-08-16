using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Repository.DTO;
using school_admin_api.Model;
using static school_admin_api.Model.Subject;

namespace school_admin_api.Repository;

public class HomeworkRepository : RepositoryBase<Homework>, IHomeworkRepository
{
    private readonly ApplicationDbContext _context;

    public HomeworkRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Create(Homework homework) => await base.Create(homework);

    public async Task Update(Homework homework) => await base.Update(homework);

    public async Task Delete(Homework homework) => await base.Delete(homework);

    public async Task<Homework?> Retrieve(Guid id, bool trackChanges = false) =>
        await FindByCondition(p => p.Id == id, trackChanges)
                .FirstOrDefaultAsync();

    // public async Task<List<Homework>> RetrieveAll() => await FindAll().ToListAsync();

    public async Task<List<HomeworkTableRowDbDTO>> RetrieveBySubjectForMainTable(Guid subjectId) =>
        await FindAll(trackChanges: false)
            .Include(t => t.Subject)
                .ThenInclude(s => s.Grade)
            .Where(homework => homework.SubjectId == subjectId &&
                homework.Subject.StateId == (byte)SUBJECT_STATES.ACTIVE &&
                homework.Subject.Grade.Active
            )
            .Select(t => new HomeworkTableRowDbDTO()
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt,
                EndsAt = t.EndsAt,
                StateId = t.StateId,
                SubjectId = t.SubjectId,
                SubjectName = t.Subject.Name,
                GradeId = t.Subject.GradeId,
                GradeName = t.Subject.Grade.Name,
            })
            .ToListAsync();
}
