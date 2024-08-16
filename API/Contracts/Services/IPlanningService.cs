using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IPlanningService
{
    Task<Guid> Create(PlanningForCreationDTO planningDTO);
    Task<PlanningTableRowDTO> Update(Guid id, PlanningForUpdateDTO planningDTO);
    Task<PlanningTableRowDTO> UpdateWithTimeBlocks(Guid id, PlanningWithTimeBlocksForUpdateDTO planningDTO);
    Task Delete(Guid id);
    Task<PlanningDTO?> Retrieve(Guid id);
    Task<List<PlanningTableRowDTO>> RetrieveAllByTeacherAndSubject(Guid teacherId, Guid subjectId);
    Task<List<LabelValueDTO<Guid>>> RetrieveByGradeAndSubjectForList(Guid gradeId, Guid subjectId);
    Task<List<PlanningTableRowDTO>> RetrieveAllByGuardianAndSubject(Guid guardianId, Guid studentId, Guid subjectId);
    Task<PlanningDTO?> RetrieveBySubjectTimeBlockAndDate(Guid subjectId, Guid timeBlockId, string dateString);
}