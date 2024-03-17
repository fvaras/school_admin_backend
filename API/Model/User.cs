using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Users", Schema = "public")]
public class User
{
    [Column("Id")]
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Rut { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte IdState { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
