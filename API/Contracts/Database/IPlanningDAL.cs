using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IPlanningDAL
{
    Task Create(Planning planning);
    Task Update(Planning planning);
    Task Delete(Planning planning);
    Task<Planning?> Retrieve(Guid id, bool trackChanges = false);
    Task<Planning?> RetrieveWithTimeBlocks(Guid id, bool trackChanges = false);
    Task<List<Planning>> RetrieveAll();
    Task<List<PlanningTableRowDbDTO>> RetrieveForMainTable(Guid id, Guid teacherId);
    Task<List<LabelValueFromDB<Guid>>> RetrieveByGradeAndSubject(Guid gradeId, Guid subjectId);
    Task<Planning?> RetrieveBySubjectTimeBlockAndDate(Guid subjectId, Guid timeBlockId, DateTime date);
}
