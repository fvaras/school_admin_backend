using school_admin_api.Model;

namespace school_admin_api.Contracts.Repository;

public interface IPlanningTimeBlockRepository
{
    Task<List<PlanningTimeBlock>> GetPlanningTimeBlocks(Guid timeBlockId, DateTimeOffset date);
}
