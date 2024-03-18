using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("StudentGuardians", Schema = "public")]
public class StudentGuardian
{
    [Column("Id")]
    public int Id { get; set; }
    public string Relation { get; set; }
    public byte StateId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User User { get; set; }

    // public ICollection<Student> Students { get; set; } = new List<Student>();
}
