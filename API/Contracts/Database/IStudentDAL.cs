using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IStudentDAL
{
    Task<int> Create(Student student);
    Task Update(Student student);
    Task Delete(Student student);
    Task<Student?> Retrieve(int id, bool trackChanges = false);
    Task<Student?> RetrieveWithUserAndProfiles(int id, bool trackChanges = true);
    Task<Student?> RetrieveWithGuardians(int id, bool trackChanges = true);
    Task<Student?> RetrieveForMainTable(int id);
    Task<List<Student>> RetrieveAll();
    Task<List<int>> RetrieveGuardiansId(int id);
}
