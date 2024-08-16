using AutoMapper;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;
using Profile = school_admin_api.Model.Profile;

namespace school_admin_api.Services;

public class GuardianService : IGuardianService
{
    private readonly ILoggerService _logger;
    private readonly IUserService _userService;
    private readonly IGuardianRepository _guardianRepository;
    private readonly IProfileRepository _profileRepository;
    private readonly IMapper _mapper;

    public GuardianService(
        ILoggerService logger,
        IUserService userService,
        IGuardianRepository guardianRepository,
        IProfileRepository profileRepository,
        IMapper mapper)
    {
        _logger = logger;
        _userService = userService;
        _guardianRepository = guardianRepository;
        _profileRepository = profileRepository;
        _mapper = mapper;
    }

    public async Task<GuardianTableRowDTO> Create(GuardianForCreationDTO guardianDTO)
    {
        // TODO: Retrieve guardian (DuplicatedEntityException)

        User user = await _userService.RetrieveByRut(guardianDTO.User.Rut, trackChanges: true);

        // Validations of existence and duplicity
        if (user is not null)
        {
            if (!user.UserName.Equals(guardianDTO.User.UserName))
                throw new InconsistentDataException("User already exists with a different username");
            if (!user.Rut.Equals(guardianDTO.User.Rut))
                throw new InconsistentDataException("User already exists with a different DNI");
        }
        else
        {
            user = await _userService.Create(guardianDTO.User);
        }

        // Get Guardian Profile
        Profile guardianProfile = await _profileRepository.Retrieve(Profile.GUARDIAN, trackChanges: true);

        // Check if the user already has the guardian profile associated
        if (!user.UserProfiles.Any(p => p.ProfileId == guardianProfile.Id))
            user.UserProfiles.Add(new()
            {
                User = user,
                Profile = guardianProfile
            });

        Guardian guardian = _mapper.Map<Guardian>(guardianDTO);
        guardian.User = user;
        guardian.CreatedAt = DateTimeOffset.UtcNow;
        guardian.UpdatedAt = DateTimeOffset.UtcNow;
        await _guardianRepository.Create(guardian);

        var guardianForMainTable = await _guardianRepository.RetrieveForMainTable(guardian.Id);
        return _mapper.Map<GuardianTableRowDTO>(guardianForMainTable);
    }

    public async Task<GuardianTableRowDTO> Update(Guid id, GuardianForUpdateDTO guardianDTO)
    {
        Guardian guardian = await GetRecordAndCheckExistence(id);
        _mapper.Map(guardianDTO, guardian);
        guardian.UpdatedAt = DateTimeOffset.UtcNow;
        await _guardianRepository.Update(guardian);

        var guardianForMainTable = await _guardianRepository.RetrieveForMainTable(id);
        return _mapper.Map<GuardianTableRowDTO>(guardianForMainTable);
    }

    public async Task Delete(Guid id)
    {
        Guardian guardian = await GetRecordAndCheckExistence(id);
        if (guardian == null)
            throw new EntityNotFoundException();

        if (guardian != null && guardian.User != null && guardian.User.UserProfiles != null)
        {
            var guardianProfile = guardian.User.UserProfiles.SingleOrDefault(p => p.ProfileId == Profile.GUARDIAN);
            if (guardianProfile != null)
                guardian.User.UserProfiles.Remove(guardianProfile);
        }
        await _guardianRepository.Delete(guardian);
    }

    public async Task<GuardianDTO?> Retrieve(Guid id) =>
        _mapper.Map<GuardianDTO>(await _guardianRepository.Retrieve(id));

    public async Task<GuardianDTO?> RetrieveByUserId(Guid userId) =>
        _mapper.Map<GuardianDTO>(await _guardianRepository.RetrieveByUserId(userId));

    public async Task<List<GuardianTableRowDTO>> RetrieveAll() =>
        _mapper.Map<List<GuardianTableRowDTO>>(await _guardianRepository.RetrieveAll());

    public async Task<List<LabelValueDTO<Guid>>> RetrieveForList(string text) =>
        _mapper.Map<List<LabelValueDTO<Guid>>>(await _guardianRepository.RetrieveForList(!string.IsNullOrWhiteSpace(text) ? text.Trim() : ""));

    public async Task<List<GuardianTableRowDTO>> RetrieveByNamesOrRut(string text) =>
        _mapper.Map<List<GuardianTableRowDTO>>(await _guardianRepository.RetrieveByNamesOrRut(text.Trim()));

    public async Task CheckRelationWithStudent(Guid guardianId, Guid studentId)
    {
        List<Guid> studentIdList = await _guardianRepository.GetStudentIds(guardianId);
        if (!studentIdList.Any(id => id == studentId))
            throw new InconsistentDataException();
    }

    private async Task<Guardian> GetRecordAndCheckExistence(Guid id)
    {
        Guardian guardian = await _guardianRepository.Retrieve(id);
        if (guardian is null)
            throw new EntityNotFoundException();
        return guardian;
    }
}
