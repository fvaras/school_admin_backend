using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface ITeacherDAL
{
    Task<int> Create(Teacher teacher);
    Task Update(Teacher teacher);
    Task Delete(Teacher teacher);
    Task<Teacher?> Retrieve(int id, bool trackChanges = false);
    Task<Teacher?> RetrieveWithUserAndProfiles(int id, bool trackChanges = true);
    Task<Teacher?> RetrieveForMainTable(int id);
    Task<List<Teacher>> RetrieveAll();

    Task<List<LabelValueFromDB<int>>> RetrieveForList();

    Task<List<UserDerivedEntityDbDataForLists<int>>> RetrieveByNamesOrRut(string text);
}
