using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class UserService : IUserService
{
    private readonly ILoggerService _logger;
    private readonly IUserDAL _userDAL;
    private readonly IMapper _mapper;

    public UserService(
        ILoggerService logger,
        IUserDAL userDAL,
        IMapper mapper)
    {
        _logger = logger;
        _userDAL = userDAL;
        _mapper = mapper;
    }

    public async Task<User> Create(UserForCreationDTO userDTO)
    {
        User user = _mapper.Map<User>(userDTO);
        user.UserName = user.UserName.ToLower();
        user.CreatedAt = DateTimeOffset.UtcNow;
        user.UpdatedAt = DateTimeOffset.UtcNow;
        // await _userDAL.Create(user);
        // return user;
        return await _userDAL.Create(user);
    }

    public async Task<User> Update(Guid id, UserForUpdateDTO userDTO)
    {
        User user = await GetRecordAndCheckExistence(id);
        _mapper.Map(userDTO, user);
        user.UpdatedAt = DateTimeOffset.UtcNow;
        await _userDAL.Update(user);
        return user;
    }

    public async Task Delete(Guid id)
    {
        User user = await GetRecordAndCheckExistence(id);
        await _userDAL.Delete(user);
    }

    public async Task<UserDTO?> Retrieve(Guid id) =>
        _mapper.Map<UserDTO>(await _userDAL.Retrieve(id));

    public async Task<List<UserDTO>> RetrieveAll() =>
        _mapper.Map<List<UserDTO>>(await _userDAL.RetrieveAll());

    private async Task<User> GetRecordAndCheckExistence(Guid id)
    {
        User user = await _userDAL.Retrieve(id);
        if (user == null)
            throw new EntityNotFoundException();
        return user;
    }
    public async Task<User?> RetrieveByRut(string rut, bool trackChanges = false) =>
        await _userDAL.RetrieveByDNI(rut, trackChanges);

    public async Task<User?> RetrieveByRutWithProfiles(string rut, bool trackChanges = false) =>
        await _userDAL.RetrieveByDNIWithProfiles(rut, trackChanges);

    public async Task<(UserInfoDTO? userInfo, Guid userId)> Validate(string username, string password, Guid profileId)
    {
        User? user = await _userDAL.RetrieveByCredentials(username.ToLower(), password, profileId);
        if (user is null || !user.UserProfiles.Select(p => p.ProfileId).Contains(profileId))  // TODO: Remove when filter by profileId in _userDAL.RetrieveByCredentials
            return (null, Guid.Empty);
        return (
            userInfo: _mapper.Map<UserInfoDTO?>(user),
            userId: user.Id
        );
    }
}
