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

    public async Task<Guid> Create(Grade grade)
    {
        await base.Create(grade);
        return grade.Id; // Assuming Id is auto-generated
    }

    public async Task Update(Grade grade) => await base.Update(grade);

    public async Task Delete(Grade grade) => await base.Delete(grade);

    public async Task<Grade?> Retrieve(Guid id, bool trackChanges = false) =>
        await FindByCondition(c => c.Id == id, trackChanges)
                // .Include(g => g.Teachers)
                .FirstOrDefaultAsync();

    public async Task<List<Grade>> RetrieveAll() => await FindAll().ToListAsync();

    public async Task<List<LabelValueFromDB<Guid>>> RetrieveForList() =>
        await FindByCondition(g => g.Active == true, false)
                .Select(g => new LabelValueFromDB<Guid>()
                {
                    Value = g.Id,
                    Label = $"{g.Name}"
                })
                .ToListAsync();

    public async Task<List<LabelValueFromDB<Guid>>> RetrieveForListByTeacher(Guid teacherId) =>
        await _context.Subject
                .Include(s => s.Grade)
                .Include(s => s.Teacher)
                    .ThenInclude(t => t.User)
                .Where(s =>
                        s.TeacherId == teacherId
                        && s.StateId == (int)Subject.SUBJECT_STATES.ACTIVE
                        && s.Teacher.StateId == (int)Teacher.TEACHER_STATES.ACTIVE
                        && s.Teacher.User.StateId == (int)User.USER_STATES.ACTIVE
                )
                .AsNoTracking()
                .Select(s => new LabelValueFromDB<Guid>()
                {
                    Value = s.Grade.Id,
                    Label = $"{s.Grade.Name}"
                })
                .Distinct()
                .ToListAsync();
    // public async Task<List<LabelValueFromDB<Guid>>> RetrieveForListByTeacher(Guid teacherId) =>
    //     await FindByCondition(g => g.Active == true, false)
    //             .Include(g => g.Teachers)
    //             .Where(g => g.Teachers.Any(t => t.Id == teacherId))
    //             .Select(g => new LabelValueFromDB<Guid>()
    //             {
    //                 Value = g.Id,
    //                 Label = $"{g.Name} ${String.Join(",", g.Teachers.Select(t => t.Id))}"
    //             })
    //             .ToListAsync();

    public async Task<List<Guid>> RetrieveTeachersId(Guid id)
    {
        return await FindByCondition(c => c.Id == id, trackChanges: false)
            .SelectMany(p => p.Teachers)
            .Select(p => p.Id)
            .ToListAsync();
    }
}
