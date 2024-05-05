using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface ITimeBlockDAL
{
    Task Create(TimeBlock timeBlock);
    Task Update(TimeBlock timeBlock);
    Task Delete(TimeBlock timeBlock);
    Task<TimeBlock?> Retrieve(int id, bool trackChanges = false);
    Task<List<TimeBlock>> RetrieveAll(int gradeId);
    Task<List<TimeBlockTableRowDbDTO>> RetrieveForMainTable(int id = 0);
}