using school_admin_api.Contracts.Repository;
using school_admin_api.Model;

namespace school_admin_api.Repository;
public class GradeTeachersRepository : RepositoryBase<GradeTeacher>, IGradeTeachersRepository
{
    private readonly ApplicationDbContext _context;

    public GradeTeachersRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task ClearTeacherAssociations(Guid gradeId, bool saveChanges = true)
    {
        var gradeTeachersList = FindByCondition(p => p.GradeId == gradeId, trackChanges: true);
        foreach (var gradeTeacher in gradeTeachersList)
            await Delete(gradeTeacher, saveChanges: saveChanges);
    }
}
