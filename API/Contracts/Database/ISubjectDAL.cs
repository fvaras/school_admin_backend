using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface ISubjectDAL
{
    Task Create(Subject subject);
    Task Update(Subject subject);
    Task Delete(Subject subject);
    Task<Subject?> Retrieve(int id, bool trackChanges = false);
    Task<List<SubjectTableRowDbDTO>> RetrieveAllForTable(int id = 0);
}
