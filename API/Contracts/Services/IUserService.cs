using school_admin_api.Contracts.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Services;

public interface IUserService
{
    Task<User> Create(UserForCreationDTO userDTO);
    Task<User> Update(Guid id, UserForUpdateDTO userDTO);
    Task Delete(Guid id);
    Task<UserDTO?> Retrieve(Guid id);
    Task<List<UserDTO>> RetrieveAll();
    Task<User?> RetrieveByRut(string rut, bool trackChanges = false);
    Task<User?> RetrieveByRutWithProfiles(string rut, bool trackChanges = false);
    Task<(UserInfoDTO? userInfo, Guid userId)> Validate(string username, string password, Guid profileId);
}
