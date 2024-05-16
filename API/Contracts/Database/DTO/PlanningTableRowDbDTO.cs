namespace school_admin_api.Contracts.Database.DTO;

public class PlanningTableRowDbDTO
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    // public string? ExpectedLearning { get; set; }
    // public string? Contents { get; set; }
    // public string? Activities { get; set; }
    // public string? Resources { get; set; }
    // public string? EvaluationPlan { get; set; }
    public TimeSpan? EstimatedDuration { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    // public string SubjectName { get; set; }
    // public DateTime CreateAt { get; set; }
    // public DateTime UpdatedAt { get; set; }
    // public int CreatedBy { get; set; }
    // public int LastUpdatedBy { get; set; }
    public byte StateId { get; set; }
}
