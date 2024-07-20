using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;
using Profile = school_admin_api.Model.Profile;

namespace school_admin_api.Services;

public class StudentService : IStudentService
{
    private readonly ILoggerService _logger;
    private readonly IUserService _userService;
    private readonly IStudentDAL _studentDAL;
    private readonly IGuardianDAL _guardianDAL;
    private readonly IProfileDAL _profileDAL;
    private readonly IMapper _mapper;

    public StudentService(
        ILoggerService logger,
        IUserService userService,
        IStudentDAL studentDAL,
        IGuardianDAL guardianDAL,
        IProfileDAL profileDAL,
        IMapper mapper
        )
    {
        _logger = logger;
        _userService = userService;
        _studentDAL = studentDAL;
        _guardianDAL = guardianDAL;
        _profileDAL = profileDAL;
        _mapper = mapper;
    }

    public async Task<StudentTableRowDTO> Create(StudentForCreationDTO studentDTO)
    {
        User user = await _userService.RetrieveByRutWithProfiles(studentDTO.User.Rut, trackChanges: true);

        // Grade null value
        if (studentDTO.GradeId == Guid.Empty)
            studentDTO.GradeId = null;

        // Validations of existence and duplicity
        if (user is not null)
        {
            if (user.UserProfiles.ToList().Find(p => p.ProfileId == Profile.STUDENT) != null)
                throw new InconsistentDataException("Student already exists with the same Rut");
            if (user.StateId == (int)User.USER_STATES.INACTIVE)
                throw new InconsistentDataException($"User rut {studentDTO.User.Rut} is not active");
        }
        else
        {
            studentDTO.User.StateId = studentDTO.StateId;  // New users => Same stateId as StudentDTO
            user = await _userService.Create(studentDTO.User);
        }

        // Get Student Profile
        Profile studentProfile = await _profileDAL.Retrieve(Profile.STUDENT, trackChanges: true);

        // Check if the user already has the student profile associated
        if (!user.UserProfiles.Any(p => p.ProfileId == studentProfile.Id))
            user.UserProfiles.Add(new UserProfile()
            {
                User = user,
                Profile = studentProfile
            });

        Student student = _mapper.Map<Student>(studentDTO);
        student.User = user;
        student.CreatedAt = DateTimeOffset.UtcNow;
        student.UpdatedAt = DateTimeOffset.UtcNow;

        /********* GUARDIANS *********/
        List<Guid> guardiansIds = new List<Guid>();
        if (studentDTO.Guardian1Id != Guid.Empty)
            guardiansIds.Add(studentDTO.Guardian1Id);
        if (studentDTO.Guardian2Id != Guid.Empty && !guardiansIds.Contains(studentDTO.Guardian2Id))
            guardiansIds.Add(studentDTO.Guardian2Id);
        foreach (Guid guardianId in guardiansIds)
            student.Guardians.Add(await _guardianDAL.Retrieve(guardianId, trackChanges: true));
        /********* GUARDIANS *********/

        await _studentDAL.Create(student);

        var studentForMainTable = await _studentDAL.RetrieveForMainTable(student.Id);
        return _mapper.Map<StudentTableRowDTO>(studentForMainTable);
    }

    public async Task<StudentTableRowDTO> Update(Guid id, StudentForUpdateDTO studentDTO)
    {
        Student student = await _studentDAL.RetrieveWithGuardians(id);
        _mapper.Map(studentDTO, student);
        student.UpdatedAt = DateTimeOffset.UtcNow;

        /********* GUARDIANS *********/
        List<Guid> guardiansIds = new List<Guid>();
        if (studentDTO.Guardian1Id != Guid.Empty)
            guardiansIds.Add(studentDTO.Guardian1Id);
        if (studentDTO.Guardian2Id != Guid.Empty && !guardiansIds.Contains(studentDTO.Guardian2Id))
            guardiansIds.Add(studentDTO.Guardian2Id);

        // Retrieve current guardian associations for comparison
        List<Guid> currentGuardianIds = await _studentDAL.RetrieveGuardiansId(id);

        // Determine guardians to remove
        var guardiansIdsToRemove = currentGuardianIds.Except(guardiansIds).ToList();
        foreach (var guardianId in guardiansIdsToRemove)
        {
            var guardianToRemove = student.Guardians.FirstOrDefault(t => t.Id == guardianId);
            if (guardianToRemove != null)
                student.Guardians.Remove(guardianToRemove);
        }

        // Determine new guardians to add
        var newGuardiansIds = guardiansIds.Except(currentGuardianIds).ToList();
        foreach (var newGuardianId in newGuardiansIds)
        {
            var guardianToAdd = await _guardianDAL.Retrieve(newGuardianId, trackChanges: true);
            if (guardianToAdd != null)
                student.Guardians.Add(guardianToAdd);
        }
        /********* GUARDIANS *********/

        // Grade null value
        if (studentDTO.GradeId == Guid.Empty)
            student.GradeId = null;

        await _studentDAL.Update(student);
        student = await _studentDAL.RetrieveForMainTable(id);
        return _mapper.Map<StudentTableRowDTO>(student);
    }

    public async Task Delete(Guid id)
    {
        Student student = await _studentDAL.RetrieveWithUserAndProfiles(id);
        if (student == null)
            throw new EntityNotFoundException();

        if (student != null && student.User != null && student.User.UserProfiles != null)
        {
            var studentProfile = student.User.UserProfiles.SingleOrDefault(p => p.ProfileId == Profile.STUDENT);
            if (studentProfile != null)
                student.User.UserProfiles.Remove(studentProfile);
        }

        student.Guardians = null;

        await _studentDAL.Delete(student);
    }

    public async Task<StudentDTO?> Retrieve(Guid id) => _mapper.Map<StudentDTO>(await _studentDAL.Retrieve(id));

    public async Task<List<StudentTableRowDTO>> RetrieveAll() => _mapper.Map<List<StudentTableRowDTO>>(await _studentDAL.RetrieveAll());

    private async Task<Student> GetRecordAndCheckExistence(Guid id)
    {
        Student student = await _studentDAL.Retrieve(id);
        if (student is null)
            throw new EntityNotFoundException();
        return student;
    }
}
