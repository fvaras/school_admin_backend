using school_admin_api.Contracts.Repository.DTO;
using school_admin_api.Model;

namespace school_admin_api.Contracts.Repository;

public interface IPlanningRepository
{
    Task Create(Planning planning);
    Task Update(Planning planning);
    Task Delete(Planning planning);
    Task<Planning?> Retrieve(Guid id, bool trackChanges = false);
    Task<Planning?> RetrieveWithTimeBlocks(Guid id, bool trackChanges = false);
    Task<List<Planning>> RetrieveAll();
    Task<List<PlanningTableRowDbDTO>> RetrieveForMainTable(Guid subjectId);
    // Task<List<LabelValueFromDB<Guid>>> RetrieveByGradeAndSubjectForList(Guid gradeId, Guid subjectId);
    // Task<List<PlanningTableRowDbDTO>> RetrieveForTable(Guid subjectId);
    Task<Planning?> RetrieveBySubjectTimeBlockAndDate(Guid subjectId, Guid timeBlockId, DateTimeOffset date);
}
