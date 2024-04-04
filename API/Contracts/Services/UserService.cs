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
        user.CreatedAt = DateTime.Now;
        user.UpdatedAt = DateTime.Now;
        // await _userDAL.Create(user);
        // return user;
        return await _userDAL.Create(user);
    }

    public async Task Update(int id, UserForUpdateDTO userDTO)
    {
        User user = await GetRecordAndCheckExistence(id);
        _mapper.Map(userDTO, user);
        user.UpdatedAt = DateTime.Now;
        await _userDAL.Update(user);
    }

    public async Task Delete(int id)
    {
        User user = await GetRecordAndCheckExistence(id);
        await _userDAL.Delete(user);
    }

    public async Task<UserDTO?> Retrieve(int id) =>
        _mapper.Map<UserDTO>(await _userDAL.Retrieve(id));

    public async Task<List<UserDTO>> RetrieveAll() =>
        _mapper.Map<List<UserDTO>>(await _userDAL.RetrieveAll());

    private async Task<User> GetRecordAndCheckExistence(int id)
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

    public async Task<UserInfoDTO?> Validate(string username, string password)
    {
        User? user = await _userDAL.RetrieveByCredentials(username.ToLower(), password);
        if (user is null)
            return null;
        return _mapper.Map<UserInfoDTO?>(user);
    }
}
