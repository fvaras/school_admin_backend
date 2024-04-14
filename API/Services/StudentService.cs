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
    private readonly IProfileDAL _profileDAL;
    private readonly IMapper _mapper;

    public StudentService(
        ILoggerService logger,
        IUserService userService,
        IStudentDAL studentDAL,
        IProfileDAL profileDAL,
        IMapper mapper
        )
    {
        _logger = logger;
        _userService = userService;
        _studentDAL = studentDAL;
        _profileDAL = profileDAL;
        _mapper = mapper;
    }

    public async Task<StudentTableRowDTO> Create(StudentForCreationDTO studentDTO)
    {
        User user = await _userService.RetrieveByRutWithProfiles(studentDTO.User.Rut, trackChanges: true);

        // Grade null value
        if (studentDTO.GradeId == 0)
            studentDTO.GradeId = null;

        // Validations of existence and duplicity
        if (user is not null)
        {
            if (user.Profiles.ToList().Find(p => p.Id == (int)Profile.PROFILES_TYPES.STUDENT) != null)
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
        Profile studentProfile = await _profileDAL.Retrieve((int)Profile.PROFILES_TYPES.STUDENT, trackChanges: true);

        // Check if the user already has the student profile associated
        if (!user.Profiles.Any(p => p.Id == studentProfile.Id))
            user.Profiles.Add(studentProfile);

        Student student = _mapper.Map<Student>(studentDTO);
        student.User = user;
        student.CreatedAt = DateTime.Now;
        student.UpdatedAt = DateTime.Now;
        await _studentDAL.Create(student);

        var studentForMainTable = await _studentDAL.RetrieveForMainTable(student.Id);
        return _mapper.Map<StudentTableRowDTO>(studentForMainTable);
    }

    public async Task<StudentTableRowDTO> Update(int id, StudentForUpdateDTO studentDTO)
    {
        Student student = await GetRecordAndCheckExistence(id);
        _mapper.Map(studentDTO, student);
        student.UpdatedAt = DateTime.Now;

        // Grade null value
        if (studentDTO.GradeId == 0)
            student.GradeId = null;

        await _studentDAL.Update(student);
        student = await _studentDAL.RetrieveForMainTable(id);
        return _mapper.Map<StudentTableRowDTO>(student);
    }

    public async Task Delete(int id)
    {
        Student student = await _studentDAL.RetrieveWithUserAndProfiles(id);
        if (student == null)
            throw new EntityNotFoundException();

        if (student != null && student.User != null && student.User.Profiles != null)
        {
            var studentProfile = student.User.Profiles.SingleOrDefault(p => p.Id == (int)Profile.PROFILES_TYPES.STUDENT);
            if (studentProfile != null)
                student.User.Profiles.Remove(studentProfile);
        }
        await _studentDAL.Delete(student);
    }

    public async Task<StudentDTO?> Retrieve(int id) => _mapper.Map<StudentDTO>(await _studentDAL.Retrieve(id));

    public async Task<List<StudentTableRowDTO>> RetrieveAll() => _mapper.Map<List<StudentTableRowDTO>>(await _studentDAL.RetrieveAll());

    private async Task<Student> GetRecordAndCheckExistence(int id)
    {
        Student student = await _studentDAL.Retrieve(id);
        if (student is null)
            throw new EntityNotFoundException();
        return student;
    }
}
