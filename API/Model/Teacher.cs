using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Teachers", Schema = "public")]
public class Teacher
{
    [Column("Id")]
    public int Id { get; set; }
    public byte IdGender { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public string Education { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public byte IdState { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User User { get; set; }

    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
