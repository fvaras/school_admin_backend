using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface ITeacherDAL
{
    Task<Guid> Create(Teacher teacher);
    Task Update(Teacher teacher);
    Task Delete(Teacher teacher);
    Task<Teacher?> Retrieve(Guid id, bool trackChanges = false);
    Task<List<Guid>> RetrieveIdByUser(Guid userId);
    Task<Teacher?> RetrieveWithUserAndProfiles(Guid id, bool trackChanges = true);
    Task<Teacher?> RetrieveForMainTable(Guid id);
    Task<List<Teacher>> RetrieveAll();

    Task<List<LabelValueFromDB<Guid>>> RetrieveForList();

    Task<List<UserDerivedEntityDbDataForLists<Guid>>> RetrieveByNamesOrRut(string text);
}
