using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IStudentDAL
{
    Task<int> Create(Student student);
    Task Update(Student student);
    Task Delete(Student student);
    Task<Student?> Retrieve(int studentId, bool trackChanges = false);
    Task<List<Student>> RetrieveAll();
}
