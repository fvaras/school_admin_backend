using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Students", Schema = "public")]
public class Student
{
    [Column("Id")]
    public int Id { get; set; }
    public string BloodGroup { get; set; }
    public string Allergies { get; set; }
    public DateTime? JoiningDate { get; set; }
    public byte StateId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User User { get; set; }

    public int? GradeId { get; set; }
    public Grade? Grade { get; set; }

    public ICollection<Guardian> Guardians { get; set; } = new List<Guardian>();
}
