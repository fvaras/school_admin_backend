using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Teachers", Schema = "public")]
public class Teacher
{
    [Column("Id")]
    public Guid Id { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public string Education { get; set; }
    public byte StateId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public User User { get; set; }

    // public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    public ICollection<GradeTeacher> GradeTeachers { get; set; } = new List<GradeTeacher>();

    public enum TEACHER_STATES
    {
        ACTIVE = 1,
        INACTIVE = 2,
    }
}
