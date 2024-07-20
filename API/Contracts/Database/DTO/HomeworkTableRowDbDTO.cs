namespace school_admin_api.Contracts.Database.DTO;

public class HomeworkTableRowDbDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset EndsAt { get; set; }
    public byte StateId { get; set; }
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
    public Guid GradeId { get; set; }
    public string GradeName { get; set; }
}
