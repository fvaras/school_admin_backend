using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Repository.DTO;
using school_admin_api.Model;

namespace school_admin_api.Repository;

public class GradeRepository : RepositoryBase<Grade>, IGradeRepository
{
    private readonly ApplicationDbContext _context;

    public GradeRepository(ApplicationDbContext context) : base(context)
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

    public async Task<Grade?> RetrieveWithTeachers(Guid id, bool trackChanges = false) =>
        await FindByCondition(c => c.Id == id, trackChanges)
                .Include(g => g.GradeTeachers)
                .FirstOrDefaultAsync();

    public async Task ClearTeacherAssociations(Guid id)
    {
        var grade = await RetrieveWithTeachers(id);
        // Remove current associations explicitly
        foreach (var teacher in grade.GradeTeachers.ToList())
        {
            _context.Entry(teacher).State = EntityState.Deleted;
        }
        await base.Delete(grade);
    }

    public async Task<List<Grade>> RetrieveAll() => await FindAll().ToListAsync();

    public async Task<List<LabelValueFromDB<Guid>>> RetrieveForList() =>
        await FindByCondition(g => g.Active == true, false)
                .Select(g => new LabelValueFromDB<Guid>()
                {
                    Value = g.Id,
                    Label = $"{g.Name}"
                })
                .ToListAsync();


    /********* TEACHER *********/
    public async Task<List<LabelValueFromDB<Guid>>> RetrieveByTeacherForList(Guid teacherId) =>
        await FindByCondition(grade => grade.Active == true, false)
                .Include(grade => grade.GradeTeachers)
                    .ThenInclude(gradeTeachers => gradeTeachers.Teacher)
                .Where(grade => grade.Active
                    && grade.GradeTeachers.Any(gradeTeacher => gradeTeacher.TeacherId == teacherId)
                )
                .SelectMany(grade => grade.GradeTeachers
                    .Where(gradeTeacher => gradeTeacher.TeacherId == teacherId)
                    .Select(gradeTeacher => new LabelValueFromDB<Guid>
                    {
                        Value = grade.Id,
                        Label = grade.Name
                    }))
                .Distinct()
                .ToListAsync();
    /********* TEACHER *********/


    public async Task<List<Guid>> RetrieveTeachersId(Guid id)
    {
        return await FindByCondition(c => c.Id == id, trackChanges: false)
            .SelectMany(p => p.GradeTeachers)
            .Select(p => p.TeacherId)
            .ToListAsync();
    }
}
