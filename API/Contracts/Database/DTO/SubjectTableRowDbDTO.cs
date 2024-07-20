namespace school_admin_api.Contracts.Database.DTO;

public class SubjectTableRowDbDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int StateId { get; set; }
    // public DateTime CreatedAt { get; set; }
    // public DateTime UpdatedAt { get; set; }

    public Guid GradeId { get; set; }
    public string GradeName { get; set; }

    public Guid TeacherId { get; set; }
    public string TeacherName { get; set; }
}
