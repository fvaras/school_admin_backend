using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IMyEntityService
{
    Task<int> Create(MyEntityForCreationDTO myEntityDTO);
    Task Update(int idMyEntity, MyEntityForUpdateDTO myEntityDTO);
    Task Delete(int idMyEntity);
    Task<MyEntityDTO?> Retrieve(int idMyEntity);
    Task<List<MyEntityDTO>> RetrieveAll();
}