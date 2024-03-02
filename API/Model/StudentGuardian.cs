using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("StudentGuardians", Schema = "public")]
public class StudentGuardian
{
    [Column("Id")]
    public int Id { get; set; }
    public string Rut { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte IdGender { get; set; }
    public string Relation { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public byte IdState { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
