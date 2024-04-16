using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;
using Profile = school_admin_api.Model.Profile;

namespace school_admin_api.Services;

public class StudentGuardianService : IStudentGuardianService
{
    private readonly ILoggerService _logger;
    private readonly IUserService _userService;
    private readonly IStudentGuardianDAL _studentGuardianDAL;
    private readonly IProfileDAL _profileDAL;
    private readonly IMapper _mapper;

    public StudentGuardianService(
        ILoggerService logger,
        IUserService userService,
        IStudentGuardianDAL studentGuardianDAL,
        IProfileDAL profileDAL,
        IMapper mapper)
    {
        _logger = logger;
        _userService = userService;
        _studentGuardianDAL = studentGuardianDAL;
        _profileDAL = profileDAL;
        _mapper = mapper;
    }

    public async Task<StudentGuardianTableRowDTO> Create(StudentGuardianForCreationDTO studentGuardianDTO)
    {
        // TODO: Retrieve studentGuardian (DuplicatedEntityException)

        User user = await _userService.RetrieveByRut(studentGuardianDTO.User.Rut, trackChanges: true);

        // Validations of existence and duplicity
        if (user is not null)
        {
            if (!user.UserName.Equals(studentGuardianDTO.User.UserName))
                throw new InconsistentDataException("User already exists with a different username");
            if (!user.Rut.Equals(studentGuardianDTO.User.Rut))
                throw new InconsistentDataException("User already exists with a different DNI");
        }
        else
        {
            user = await _userService.Create(studentGuardianDTO.User);
        }

        // Get StudentGuardian Profile
        Profile studentGuardianProfile = await _profileDAL.Retrieve((int)Profile.PROFILES_TYPES.STUDENT_GUARDIAN, trackChanges: true);

        // Check if the user already has the studentGuardian profile associated
        if (!user.Profiles.Any(p => p.Id == studentGuardianProfile.Id))
            user.Profiles.Add(studentGuardianProfile);

        StudentGuardian studentGuardian = _mapper.Map<StudentGuardian>(studentGuardianDTO);
        studentGuardian.User = user;
        studentGuardian.CreatedAt = DateTime.Now;
        studentGuardian.UpdatedAt = DateTime.Now;
        await _studentGuardianDAL.Create(studentGuardian);

        var studentGuardianForMainTable = await _studentGuardianDAL.RetrieveForMainTable(studentGuardian.Id);
        return _mapper.Map<StudentGuardianTableRowDTO>(studentGuardianForMainTable);
    }

    public async Task<StudentGuardianTableRowDTO> Update(int id, StudentGuardianForUpdateDTO studentGuardianDTO)
    {
        StudentGuardian studentGuardian = await GetRecordAndCheckExistence(id);
        _mapper.Map(studentGuardianDTO, studentGuardian);
        studentGuardian.UpdatedAt = DateTime.Now;
        await _studentGuardianDAL.Update(studentGuardian);

        var studentGuardianForMainTable = await _studentGuardianDAL.RetrieveForMainTable(id);
        return _mapper.Map<StudentGuardianTableRowDTO>(studentGuardianForMainTable);
    }

    public async Task Delete(int id)
    {
        StudentGuardian studentGuardian = await GetRecordAndCheckExistence(id);
        if (studentGuardian == null)
            throw new EntityNotFoundException();

        if (studentGuardian != null && studentGuardian.User != null && studentGuardian.User.Profiles != null)
        {
            var studentGuardianProfile = studentGuardian.User.Profiles.SingleOrDefault(p => p.Id == (int)Profile.PROFILES_TYPES.STUDENT_GUARDIAN);
            if (studentGuardianProfile != null)
                studentGuardian.User.Profiles.Remove(studentGuardianProfile);
        }
        await _studentGuardianDAL.Delete(studentGuardian);
    }

    public async Task<StudentGuardianDTO?> Retrieve(int id) =>
        _mapper.Map<StudentGuardianDTO>(await _studentGuardianDAL.Retrieve(id));

    public async Task<List<StudentGuardianTableRowDTO>> RetrieveAll() =>
        _mapper.Map<List<StudentGuardianTableRowDTO>>(await _studentGuardianDAL.RetrieveAll());

    private async Task<StudentGuardian> GetRecordAndCheckExistence(int id)
    {
        StudentGuardian studentGuardian = await _studentGuardianDAL.Retrieve(id);
        if (studentGuardian is null)
            throw new EntityNotFoundException();
        return studentGuardian;
    }
}
