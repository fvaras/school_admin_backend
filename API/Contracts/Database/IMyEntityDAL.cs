using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IMyEntityDAL
{
    Task<int> Create(MyEntity myEntity);
    Task Update(MyEntity myEntity);
    Task Delete(MyEntity myEntity);
    Task<MyEntity?> Retrieve(int idMyEntity, bool trackChanges = false);
    Task<List<MyEntity>> RetrieveAll();
}