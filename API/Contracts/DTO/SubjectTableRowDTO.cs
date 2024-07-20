namespace school_admin_api.Contracts.DTO;

public class SubjectTableRowDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int StateId { get; set; }
    // public DateTimeOffset CreatedAt { get; set; }
    // public DateTimeOffset UpdatedAt { get; set; }

    public Guid GradeId { get; set; }
    public string GradeName { get; set; }

    public Guid TeacherId { get; set; }
    public string TeacherName { get; set; }
}
