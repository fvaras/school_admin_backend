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

    public async Task<int> Create(StudentForCreationDTO studentDTO)
    {
        // TODO: Retrieve student (DuplicatedEntityException)

        User user = await _userService.RetrieveByRut(studentDTO.User.Rut, trackChanges: true);

        // Validations of existence and duplicity
        if (user is not null)
        {
            if (!user.UserName.Equals(studentDTO.User.UserName))
                throw new InconsistentDataException("User already exists with a different username");
            if (!user.Rut.Equals(studentDTO.User.Rut))
                throw new InconsistentDataException("User already exists with a different DNI");
        }
        else
        {
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
        return await _studentDAL.Create(student);
    }

    public async Task Update(int id, StudentForUpdateDTO studentDTO)
    {
        Student student = await GetRecordAndCheckExistence(id);
        _mapper.Map(studentDTO, student);
        student.UpdatedAt = DateTime.Now;
        await _studentDAL.Update(student);
    }

    public async Task Delete(int id)
    {
        Student student = await GetRecordAndCheckExistence(id);
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
