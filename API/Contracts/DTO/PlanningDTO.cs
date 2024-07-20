namespace school_admin_api.Contracts.DTO;

public class PlanningBaseDTO
{
    public Guid SubjectId { get; init; }
    public string Title { get; init; }
    public string? Description { get; init; }
    public string? ExpectedLearning { get; init; }
    public string? Contents { get; init; }
    public string? Activities { get; init; }
    public string? Resources { get; init; }
    public string? EvaluationPlan { get; init; }
    public TimeSpan? EstimatedDuration { get; init; }
    // public DateTime? StartDate { get; init; }
    // public DateTime? EndDate { get; init; }
}

public class PlanningForCreationDTO : PlanningBaseDTO
{
}

public class PlanningForUpdateDTO : PlanningBaseDTO
{
    public Guid Id { get; init; }
}

public class PlanningDTO : PlanningBaseDTO
{
    public Guid Id { get; init; }
}

public class PlanningTableRowDTO
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
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    // public string SubjectName { get; set; }
    // public DateTime CreateAt { get; set; }
    // public DateTime UpdatedAt { get; set; }
    // public Guid CreatedBy { get; set; }
    // public Guid LastUpdatedBy { get; set; }
    public byte StateId { get; set; }
}

public class PlanningWithTimeBlocksForUpdateDTO : PlanningForUpdateDTO
{
    public Guid TimeBlockId { get; set; }
    public Guid OriginalPlanningId { get; set; }
    public DateTime Date { get; set; }
    // public bool IsAddition { get; set; } = true;
}