using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Subjects", Schema = "public")]
public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Color { get; set; }
    public int StateId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int GradeId { get; set; }
    public Grade Grade { get; set; }

    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public enum SUBJECT_STATES
    {
        ACTIVE = 1,
        INACTIVE = 2,
    }
}
