using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IPlanningTimeBlockDAL
{
    Task<List<PlanningTimeBlock>> GetPlanningTimeBlocks(int timeBlockId, DateTime date);
}
