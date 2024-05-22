using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IPlanningService
{
    Task<PlanningTableRowDTO> Create(PlanningForCreationDTO planningDTO);
    Task<PlanningTableRowDTO> Update(int id, PlanningForUpdateDTO planningDTO);
    Task<PlanningTableRowDTO> UpdateWithTimeBlocks(int id, PlanningWithTimeBlocksForUpdateDTO planningDTO);
    Task Delete(int id);
    Task<PlanningDTO?> Retrieve(int id);
    Task<List<PlanningTableRowDTO>> RetrieveAll(int teacherId);
    Task<List<LabelValueDTO<int>>> RetrieveByGradeAndSubject(int gradeId, int subjectId);
    Task<PlanningDTO?> RetrieveBySubjectTimeBlockAndDate(int subjectId, int timeBlockId, string dateString);
}