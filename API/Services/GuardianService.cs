using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;
using Profile = school_admin_api.Model.Profile;

namespace school_admin_api.Services;

public class GuardianService : IGuardianService
{
    private readonly ILoggerService _logger;
    private readonly IUserService _userService;
    private readonly IGuardianDAL _guardianDAL;
    private readonly IProfileDAL _profileDAL;
    private readonly IMapper _mapper;

    public GuardianService(
        ILoggerService logger,
        IUserService userService,
        IGuardianDAL guardianDAL,
        IProfileDAL profileDAL,
        IMapper mapper)
    {
        _logger = logger;
        _userService = userService;
        _guardianDAL = guardianDAL;
        _profileDAL = profileDAL;
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
        Profile guardianProfile = await _profileDAL.Retrieve((int)Profile.PROFILES_TYPES.STUDENT_GUARDIAN, trackChanges: true);

        // Check if the user already has the guardian profile associated
        if (!user.Profiles.Any(p => p.Id == guardianProfile.Id))
            user.Profiles.Add(guardianProfile);

        Guardian guardian = _mapper.Map<Guardian>(guardianDTO);
        guardian.User = user;
        guardian.CreatedAt = DateTime.Now;
        guardian.UpdatedAt = DateTime.Now;
        await _guardianDAL.Create(guardian);

        var guardianForMainTable = await _guardianDAL.RetrieveForMainTable(guardian.Id);
        return _mapper.Map<GuardianTableRowDTO>(guardianForMainTable);
    }

    public async Task<GuardianTableRowDTO> Update(int id, GuardianForUpdateDTO guardianDTO)
    {
        Guardian guardian = await GetRecordAndCheckExistence(id);
        _mapper.Map(guardianDTO, guardian);
        guardian.UpdatedAt = DateTime.Now;
        await _guardianDAL.Update(guardian);

        var guardianForMainTable = await _guardianDAL.RetrieveForMainTable(id);
        return _mapper.Map<GuardianTableRowDTO>(guardianForMainTable);
    }

    public async Task Delete(int id)
    {
        Guardian guardian = await GetRecordAndCheckExistence(id);
        if (guardian == null)
            throw new EntityNotFoundException();

        if (guardian != null && guardian.User != null && guardian.User.Profiles != null)
        {
            var guardianProfile = guardian.User.Profiles.SingleOrDefault(p => p.Id == (int)Profile.PROFILES_TYPES.STUDENT_GUARDIAN);
            if (guardianProfile != null)
                guardian.User.Profiles.Remove(guardianProfile);
        }
        await _guardianDAL.Delete(guardian);
    }

    public async Task<GuardianDTO?> Retrieve(int id) =>
        _mapper.Map<GuardianDTO>(await _guardianDAL.Retrieve(id));

    public async Task<List<GuardianTableRowDTO>> RetrieveAll() =>
        _mapper.Map<List<GuardianTableRowDTO>>(await _guardianDAL.RetrieveAll());

    public async Task<List<GuardianTableRowDTO>> RetrieveByNamesOrRut(string text) =>
        _mapper.Map<List<GuardianTableRowDTO>>(await _guardianDAL.RetrieveByNamesOrRut(text.Trim()));

    private async Task<Guardian> GetRecordAndCheckExistence(int id)
    {
        Guardian guardian = await _guardianDAL.Retrieve(id);
        if (guardian is null)
            throw new EntityNotFoundException();
        return guardian;
    }
}
