using school_admin_api.Contracts.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Services;

public interface IUserService
{
    Task<User> Create(UserForCreationDTO userDTO);
    Task<User> Update(int id, UserForUpdateDTO userDTO);
    Task Delete(int id);
    Task<UserDTO?> Retrieve(int id);
    Task<List<UserDTO>> RetrieveAll();
    Task<User?> RetrieveByRut(string rut, bool trackChanges = false);
    Task<User?> RetrieveByRutWithProfiles(string rut, bool trackChanges = false);
    Task<UserInfoDTO?> Validate(string username, string password, int profileId);
}
