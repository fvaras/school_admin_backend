using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IPlanningDAL
{
    Task Create(Planning planning);
    Task Update(Planning planning);
    Task Delete(Planning planning);
    Task<Planning?> Retrieve(int id, bool trackChanges = false);
    Task<Planning?> RetrieveWithTimeBlocks(int id, bool trackChanges = false);
    Task<List<Planning>> RetrieveAll();
    Task<List<PlanningTableRowDbDTO>> RetrieveForMainTable(int id = 0, int teacherId = 0);
    Task<List<LabelValueFromDB<int>>> RetrieveByGradeAndSubject(int gradeId, int subjectId);
    Task<Planning?> RetrieveBySubjectTimeBlockAndDate(int subjectId, int timeBlockId, DateTime date);
}
