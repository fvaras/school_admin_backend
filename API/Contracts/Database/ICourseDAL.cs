using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface ICourseDAL
{
    Task<int> Create(Course course);
    Task Update(Course course);
    Task Delete(Course course);
    Task<Course?> Retrieve(int id, bool trackChanges = false);
    Task<List<Course>> RetrieveAll();
}
