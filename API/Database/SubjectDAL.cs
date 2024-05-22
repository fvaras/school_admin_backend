using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class SubjectDAL : RepositoryBase<Subject>, ISubjectDAL
{
    private readonly ApplicationDbContext _context;

    public SubjectDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task Create(Subject subject)
    {
        await base.Create(subject);
    }

    public async Task Update(Subject subject) => await base.Update(subject);

    public async Task Delete(Subject subject) => await base.Delete(subject);

    public async Task<Subject?> Retrieve(int id, bool trackChanges = false) =>
        await FindByCondition(p => p.Id == id, trackChanges)
                .FirstOrDefaultAsync();

    public async Task<List<SubjectTableRowDbDTO>> RetrieveAllForTable(int id = 0) =>
        await FindAll(trackChanges: false)
            .Where(t => t.Id == id || id == 0)
            .Include(t => t.Grade)
            .Include(t => t.Teacher)
                .ThenInclude(t => t.User)
            .Select(t => new SubjectTableRowDbDTO()
            {
                Id = t.Id,
                Name = t.Name,
                StateId = t.StateId,
                // CreatedAt = t.CreatedAt,
                // UpdatedAt = t.UpdatedAt,
                GradeId = t.GradeId,
                GradeName = t.Grade.Name,
                TeacherId = t.TeacherId,
                TeacherName = $"{t.Teacher.User.FirstName} {t.Teacher.User.LastName}",
            })
            .ToListAsync();

    public async Task<List<LabelValueFromDB<int>>> RetrieveByGradeAndTeacherForList(int gradeId, int teacherId) =>
        await FindByCondition(t => t.StateId == 1, false)
                .Where(subject => subject.StateId == (int)Subject.SUBJECT_STATES.ACTIVE && subject.GradeId == gradeId
                    && (subject.TeacherId == teacherId || teacherId == 0))
                .Select(subject => new LabelValueFromDB<int>()
                {
                    Value = subject.Id,
                    Label = $"{subject.Name}"
                })
                .ToListAsync();
}
