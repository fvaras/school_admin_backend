using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Plannings", Schema = "public")]
public class Planning
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; } = null;
    public string? ExpectedLearning { get; set; } = null;
    public string? Contents { get; set; } = null;
    public string? Activities { get; set; } = null;
    public string? Resources { get; set; } = null;
    public string? EvaluationPlan { get; set; } = null;
    public TimeSpan? EstimatedDuration { get; set; } = null;
    public DateTime? StartDate { get; set; } = null;
    public DateTime? EndDate { get; set; } = null;
    public Subject Subject { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatedBy { get; set; }
    public int LastUpdatedBy { get; set; }
    public byte StateId { get; set; }
    public List<PlanningTimeBlock> PlanningTimeBlocks { get; set; }

    public enum PLANNING_STATES
    {
        ACTIVE = 1,
        IN_CREATION = 2,
        INACTIVE = 3,
    }
}
