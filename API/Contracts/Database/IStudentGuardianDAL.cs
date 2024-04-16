using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IStudentGuardianDAL
{
    Task<int> Create(StudentGuardian studentGuardian);
    Task Update(StudentGuardian studentGuardian);
    Task Delete(StudentGuardian studentGuardian);
    Task<StudentGuardian?> Retrieve(int id, bool trackChanges = false);
    Task<StudentGuardian?> RetrieveForMainTable(int id);
    Task<List<StudentGuardian>> RetrieveAll();
}
