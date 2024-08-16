using AutoMapper;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;
using Profile = school_admin_api.Model.Profile;

namespace school_admin_api.Services;

public class TeacherService : ITeacherService
{
    private readonly ILoggerService _logger;
    private readonly IUserService _userService;
    private readonly IProfileService _profileService;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IProfileRepository _profileRepository;
    private readonly IMapper _mapper;

    public TeacherService(
        ILoggerService logger,
        IUserService userService,
        IProfileService profileService,
        ITeacherRepository teacherRepository,
        IProfileRepository profileRepository,
        IMapper mapper)
    {
        _logger = logger;
        _userService = userService;
        _profileService = profileService;
        _teacherRepository = teacherRepository;
        _profileRepository = profileRepository;
        _mapper = mapper;
    }

    public async Task<TeacherTableRowDTO> Create(TeacherForCreationDTO teacherDTO)
    {
        User user = await _userService.RetrieveByRutWithProfiles(teacherDTO.User.Rut, trackChanges: true);

        // Validations of existence and duplicity
        if (user is not null)
        {
            if (user.UserProfiles.ToList().Find(p => p.ProfileId == Profile.TEACHER) != null)
                throw new InconsistentDataException("Teacher already exists with the same Rut");
            if (user.StateId == (int)User.USER_STATES.INACTIVE)
                throw new InconsistentDataException($"User rut {teacherDTO.User.Rut} is not active");
            // TODO: Verify email duplicity
        }
        else
        {
            // TODO: Verify email duplicity
            teacherDTO.User.StateId = teacherDTO.StateId;  // New users => Same stateId as TeacherDTO
            user = await _userService.Create(teacherDTO.User);
        }

        // Get Teacher Profile
        Profile teacherProfile = await _profileRepository.Retrieve(Profile.TEACHER, trackChanges: true);
        // Profile teacherProfile = await _profileService.Retrieve(Profile.TEACHER);

        // Check if the user already has the teacher profile associated
        if (!user.UserProfiles.Any(p => p.ProfileId == teacherProfile.Id))
            user.UserProfiles.Add(new()
            {
                Profile = teacherProfile,
                User = user
            });

        Teacher teacher = _mapper.Map<Teacher>(teacherDTO);
        teacher.User = user;
        teacher.CreatedAt = DateTimeOffset.UtcNow;
        teacher.UpdatedAt = DateTimeOffset.UtcNow;
        await _teacherRepository.Create(teacher);
        return _mapper.Map<TeacherTableRowDTO>(teacher);
    }

    public async Task<TeacherTableRowDTO> Update(Guid id, TeacherForUpdateDTO teacherDTO)
    {
        Teacher teacher = await GetRecordAndCheckExistence(id);
        _mapper.Map(teacherDTO, teacher);
        teacher.UpdatedAt = DateTimeOffset.UtcNow;
        await _teacherRepository.Update(teacher);
        teacher = await _teacherRepository.RetrieveForMainTable(id);
        return _mapper.Map<TeacherTableRowDTO>(teacher);
    }

    public async Task Delete(Guid id)
    {
        Teacher teacher = await _teacherRepository.RetrieveWithUserAndProfiles(id);
        if (teacher == null)
            throw new EntityNotFoundException();

        if (teacher != null && teacher.User != null && teacher.User.UserProfiles != null)
        {
            var teacherProfile = teacher.User.UserProfiles.SingleOrDefault(p => p.ProfileId == Profile.TEACHER);
            if (teacherProfile != null)
                teacher.User.UserProfiles.Remove(teacherProfile);
        }

        await _teacherRepository.Delete(teacher);
    }

    public async Task<TeacherDTO?> Retrieve(Guid id) => _mapper.Map<TeacherDTO>(await _teacherRepository.Retrieve(id));

    public async Task<List<Guid>> RetrieveIdByUser(Guid userId) => await _teacherRepository.RetrieveIdByUser(userId);


    public async Task<List<TeacherTableRowDTO>> RetrieveAll() =>
        _mapper.Map<List<TeacherTableRowDTO>>(await _teacherRepository.RetrieveAll());

    public async Task<List<LabelValueDTO<Guid>>> RetrieveForList() =>
        _mapper.Map<List<LabelValueDTO<Guid>>>(await _teacherRepository.RetrieveForList());

    public async Task<List<UserDerivedEntityDataForLists<int>>> RetrieveByNamesOrRut(string text) =>
        _mapper.Map<List<UserDerivedEntityDataForLists<int>>>(await _teacherRepository.RetrieveByNamesOrRut(text.Trim()));

    private async Task<Teacher> GetRecordAndCheckExistence(Guid id)
    {
        Teacher teacher = await _teacherRepository.Retrieve(id);
        if (teacher == null)
            throw new EntityNotFoundException();
        return teacher;
    }
}
