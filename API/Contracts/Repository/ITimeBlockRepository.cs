using school_admin_api.Contracts.Repository.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Repository;

public interface ITimeBlockRepository
{
    Task Create(TimeBlock timeBlock);
    Task Update(TimeBlock timeBlock);
    Task Delete(TimeBlock timeBlock);
    Task<TimeBlock?> Retrieve(Guid id, bool trackChanges = false);
    Task<List<TimeBlock>> RetrieveAll(Guid gradeId, Guid teacherId);
    Task<List<TimeBlockTableRowDbDTO>> RetrieveForMainTable(Guid id);
}