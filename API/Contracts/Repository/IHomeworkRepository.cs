using school_admin_api.Contracts.Repository.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Repository;

public interface IHomeworkRepository
{
    Task Create(Homework homework);
    Task Update(Homework homework);
    Task Delete(Homework homework);
    Task<Homework?> Retrieve(Guid id, bool trackChanges = false);
    // Task<List<Homework>> RetrieveAll();
    Task<List<HomeworkTableRowDbDTO>> RetrieveBySubjectForMainTable(Guid subjectId);
}
