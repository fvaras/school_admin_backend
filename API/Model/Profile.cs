using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Profiles", Schema = "public")]
public class Profile
{
    [Column("Id")]
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();

    public enum PROFILES_TYPES
    {
        ADMINISTRATOR = 1,
        TEACHER = 2,
        STUDENT = 3,
        GUARDIAN = 4,
    }
}
