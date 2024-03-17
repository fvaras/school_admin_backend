using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;
using Profile = school_admin_api.Model.Profile;

namespace school_admin_api.Services;

public class TeacherService : ITeacherService
{
    private readonly ILoggerService _logger;
    private readonly IUserService _userService;
    private readonly IProfileService _profileService;
    private readonly ITeacherDAL _teacherDAL;
    private readonly IProfileDAL _profileDAL;
    private readonly IMapper _mapper;

    public TeacherService(
        ILoggerService logger,
        IUserService userService,
        IProfileService profileService,
        ITeacherDAL teacherDAL,
        IProfileDAL profileDAL,
        IMapper mapper)
    {
        _logger = logger;
        _userService = userService;
        _profileService = profileService;
        _teacherDAL = teacherDAL;
        _profileDAL = profileDAL;
        _mapper = mapper;
    }

    public async Task<int> Create(TeacherForCreationDTO teacherDTO)
    {
        // TODO: Retrieve teacher (DuplicatedEntityException)

        User user = await _userService.RetrieveByRut(teacherDTO.User.Rut, trackChanges: true);

        // Validations of existence and duplicity
        if (user is not null)
        {
            if (!user.UserName.Equals(teacherDTO.User.UserName))
                throw new InconsistentDataException("User already exists with a different username");
            if (!user.Rut.Equals(teacherDTO.User.Rut))
                throw new InconsistentDataException("User already exists with a different DNI");
        }
        else
        {
            user = await _userService.Create(teacherDTO.User);
        }

        // Get Teacher Profile
        Profile teacherProfile = await _profileDAL.Retrieve((int)Profile.PROFILES_TYPES.TEACHER, trackChanges: true);
        // Profile teacherProfile = await _profileService.Retrieve((int)Profile.PROFILES_TYPES.TEACHER);

        // Check if the user already has the teacher profile associated
        if (!user.Profiles.Any(p => p.Id == teacherProfile.Id))
            user.Profiles.Add(teacherProfile);

        Teacher teacher = _mapper.Map<Teacher>(teacherDTO);
        teacher.User = user;
        // teacher.User.Profiles.Add(teacherProfile);
        teacher.CreatedAt = DateTime.Now;
        teacher.UpdatedAt = DateTime.Now;
        int teacherId = await _teacherDAL.Create(teacher);

        return teacherId;
    }

    public async Task Update(int id, TeacherForUpdateDTO teacherDTO)
    {
        Teacher teacher = await GetRecordAndCheckExistence(id);
        _mapper.Map(teacherDTO, teacher);
        teacher.UpdatedAt = DateTime.Now;
        await _teacherDAL.Update(teacher);
    }

    public async Task Delete(int id)
    {
        Teacher teacher = await _teacherDAL.RetrieveWithProfiles(id);
        if (teacher == null)
            throw new EntityNotFoundException();

        if (teacher != null && teacher.User != null && teacher.User.Profiles != null)
        {
            var teacherProfile = teacher.User.Profiles.SingleOrDefault(p => p.Id == (int)Profile.PROFILES_TYPES.TEACHER);
            if (teacherProfile != null)
                teacher.User.Profiles.Remove(teacherProfile);
        }

        await _teacherDAL.Delete(teacher);
    }

    public async Task<TeacherDTO?> Retrieve(int id) =>
        _mapper.Map<TeacherDTO>(await _teacherDAL.Retrieve(id));

    public async Task<List<TeacherDTO>> RetrieveAll() =>
        _mapper.Map<List<TeacherDTO>>(await _teacherDAL.RetrieveAll());

    public async Task<List<LabelValueDTO<int>>> RetrieveForList() =>
        _mapper.Map<List<LabelValueDTO<int>>>(await _teacherDAL.RetrieveForList());

    private async Task<Teacher> GetRecordAndCheckExistence(int id)
    {
        Teacher teacher = await _teacherDAL.Retrieve(id);
        if (teacher == null)
            throw new EntityNotFoundException();
        return teacher;
    }
}
