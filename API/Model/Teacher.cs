using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Teachers", Schema = "public")]
public class Teacher
{
    [Column("Id")]
    public int Id { get; set; }
    public string Rut { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte IdGender { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public string PersonalEmail { get; set; }
    public string PersonalPhone { get; set; }
    public string PersonalAddress { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Education { get; set; }
    public byte IdState { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
