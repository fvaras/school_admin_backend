namespace school_admin_api.Contracts.Repository.DTO;

public class PlanningTableRowDbDTO
{
    public Guid Id { get; set; }
    public Guid GradeId { get; set; }
    public string GradeName { get; set; }
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    // public string? ExpectedLearning { get; set; }
    // public string? Contents { get; set; }
    // public string? Activities { get; set; }
    // public string? Resources { get; set; }
    // public string? EvaluationPlan { get; set; }
    public TimeSpan? EstimatedDuration { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    // public string SubjectName { get; set; }
    // public DateTimeOffset CreateAt { get; set; }
    // public DateTimeOffset UpdatedAt { get; set; }
    // public Guid CreatedBy { get; set; }
    // public Guid LastUpdatedBy { get; set; }
    public byte StateId { get; set; }
}
