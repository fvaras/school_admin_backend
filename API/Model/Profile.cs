using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Profiles", Schema = "public")]
public class Profile
{
    [Column("Id")]
    public Guid Id { get; set; }
    public string Name { get; set; }

    // public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

    // public enum PROFILES_TYPES
    // {
    //     ADMINISTRATOR = 1,
    //     TEACHER = 2,
    //     STUDENT = 3,
    //     STUDENT_GUARDIAN = 4,
    // }
    public static readonly Guid ADMINISTRATOR = Guid.Parse("ccd8f71e-b6a6-4b04-84cf-ee3bcea3999c");
    public static readonly Guid TEACHER = Guid.Parse("398d52f1-0d94-40f9-8ef2-bc801c714490");
    public static readonly Guid STUDENT = Guid.Parse("521c2799-f386-4ea2-ba2f-64a81f86fd9d");
    public static readonly Guid GUARDIAN = Guid.Parse("9282b9d9-4c59-41c9-859a-58d37551fcae");
}