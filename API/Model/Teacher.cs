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
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User User { get; set; }

    public ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public enum TEACHER_STATES
    {
        ACTIVE = 1,
        INACTIVE = 2,
    }
}
