using AutoMapper;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class UserService : IUserService
{
    private readonly ILoggerService _logger;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(
        ILoggerService logger,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _logger = logger;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<User> Create(UserForCreationDTO userDTO)
    {
        User user = _mapper.Map<User>(userDTO);
        user.UserName = user.UserName.ToLower();
        user.CreatedAt = DateTimeOffset.UtcNow;
        user.UpdatedAt = DateTimeOffset.UtcNow;
        // await _userRepository.Create(user);
        // return user;
        return await _userRepository.Create(user);
    }

    public async Task<User> Update(Guid id, UserForUpdateDTO userDTO)
    {
        User user = await GetRecordAndCheckExistence(id);
        _mapper.Map(userDTO, user);
        user.UpdatedAt = DateTimeOffset.UtcNow;
        await _userRepository.Update(user);
        return user;
    }

    public async Task Delete(Guid id)
    {
        User user = await GetRecordAndCheckExistence(id);
        await _userRepository.Delete(user);
    }

    public async Task<UserDTO?> Retrieve(Guid id) =>
        _mapper.Map<UserDTO>(await _userRepository.Retrieve(id));

    public async Task<List<UserDTO>> RetrieveAll() =>
        _mapper.Map<List<UserDTO>>(await _userRepository.RetrieveAll());

    private async Task<User> GetRecordAndCheckExistence(Guid id)
    {
        User user = await _userRepository.Retrieve(id);
        if (user == null)
            throw new EntityNotFoundException();
        return user;
    }
    public async Task<User?> RetrieveByRut(string rut, bool trackChanges = false) =>
        await _userRepository.RetrieveByDNI(rut, trackChanges);

    public async Task<User?> RetrieveByRutWithProfiles(string rut, bool trackChanges = false) =>
        await _userRepository.RetrieveByDNIWithProfiles(rut, trackChanges);

    public async Task<(UserInfoDTO? userInfo, Guid userId)> Validate(string username, string password, Guid profileId)
    {
        User? user = await _userRepository.RetrieveByCredentials(username.ToLower(), password, profileId);
        if (user is null || !user.UserProfiles.Select(p => p.ProfileId).Contains(profileId))  // TODO: Remove when filter by profileId in _userRepository.RetrieveByCredentials
            return (null, Guid.Empty);
        return (
            userInfo: _mapper.Map<UserInfoDTO?>(user),
            userId: user.Id
        );
    }
}
