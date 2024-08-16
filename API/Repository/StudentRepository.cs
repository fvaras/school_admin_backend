using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Repository.DTO;
using school_admin_api.Model;
using static school_admin_api.Model.Student;
using static school_admin_api.Model.User;

namespace school_admin_api.Repository;

public class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Student student)
    {
        await base.Create(student);
        return student.Id;
    }

    public async Task Update(Student student) => await base.Update(student);

    public async Task Delete(Student student) => await base.Delete(student);

    public async Task<Student?> Retrieve(Guid id, bool trackChanges = false) =>
        await FindByCondition(a => a.Id == id, trackChanges)
                .Include(p => p.User)
                .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Student?> RetrieveByUserId(Guid userId, bool trackChanges = false) =>
        await FindByCondition(student => student.StateId == (byte)STUDENT_STATES.ACTIVE, trackChanges)
                .Include(p => p.User)
                .Where(guardian => guardian.User.Id == userId && guardian.User.StateId == (byte)USER_STATES.ACTIVE)
                .FirstOrDefaultAsync();

    public async Task<Student?> RetrieveWithUserAndProfiles(Guid id, bool trackChanges = true) =>
        await FindByCondition(a => a.Id == id, trackChanges)
                .Include(t => t.User)
                    .ThenInclude(u => u.UserProfiles)
                .FirstOrDefaultAsync();

    public async Task<Student?> RetrieveWithGuardians(Guid id, bool trackChanges = true) =>
        await FindByCondition(a => a.Id == id, trackChanges)
                .Include(t => t.Guardians)
                .FirstOrDefaultAsync();

    public async Task<Student?> RetrieveForMainTable(Guid id) =>
        await FindByCondition(a => a.Id == id, trackChanges: false)
                .Include(p => p.Grade)
                .Include(t => t.User)
                .FirstOrDefaultAsync();

    public async Task<List<Student>> RetrieveAll() =>
        await FindAll()
                .Where(t => t.User.StateId == (int)User.USER_STATES.ACTIVE)
                .Include(t => t.User)
                .Include(t => t.Grade)
                .ToListAsync();

    public async Task<List<Guid>> RetrieveGuardiansId(Guid id) =>
        await FindByCondition(c => c.Id == id, trackChanges: false)
                .SelectMany(p => p.Guardians)
                .Select(p => p.Id)
                .ToListAsync();

    /********* GUARDIAN *********/
    public async Task<List<LabelValueFromDB<Guid>>> GetByGuardianForList(Guid guardianId, Guid studentId) =>
        await FindByCondition(student => student.StateId == (byte)STUDENT_STATES.ACTIVE, false)
                .Include(student => student.User)
                .Include(student => student.Grade)
                .Include(student => student.Guardians)
                    .ThenInclude(guardian => guardian.User)
                .Where(student =>
                        student.Guardians.Any(guardian => guardian.Id == guardianId && guardian.StateId == (byte)USER_STATES.ACTIVE)
                        && student.User.StateId == (byte)USER_STATES.ACTIVE
                        && (studentId == Guid.Empty || student.Id == studentId)
                // && student.Grade.Active == true
                )
                .Select(student => new LabelValueFromDB<Guid>()
                {
                    Value = student.Id,
                    Label = $"{student.User.FirstName} {student.User.LastName} | {student.Grade.Name}",
                })
                .ToListAsync();
    /********* GUARDIAN *********/
}
