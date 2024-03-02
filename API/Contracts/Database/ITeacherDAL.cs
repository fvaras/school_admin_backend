using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface ITeacherDAL
{
    Task<int> Create(Teacher teacher);
    Task Update(Teacher teacher);
    Task Delete(Teacher teacher);
    Task<Teacher?> Retrieve(int id, bool trackChanges = false);
    Task<List<Teacher>> RetrieveAll();
}
