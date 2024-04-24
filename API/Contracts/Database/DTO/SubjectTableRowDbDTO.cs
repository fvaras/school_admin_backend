namespace school_admin_api.Contracts.Database.DTO;

public class SubjectTableRowDbDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int StateId { get; set; }
    // public DateTime CreatedAt { get; set; }
    // public DateTime UpdatedAt { get; set; }

    public int GradeId { get; set; }
    public string GradeName { get; set; }

    public int TeacherId { get; set; }
    public string TeacherName { get; set; }
}
