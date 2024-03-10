using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Students", Schema = "public")]
public class Student
{
    [Column("Id")]
    public int Id { get; set; }
    public string Rut { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte IdGender { get; set; }
    public string Address { get; set; }
    public string BloodGroup { get; set; }
    public string Allergies { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime? JoiningDate { get; set; }
    public DateTime? BirthDate { get; set; }
    public int StateId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }


    // public int? GradeId { get; set; } // Foreign key property for Grade
    // public Grade Grade { get; set; } // Navigation property for Grade

    // public ICollection<StudentGuardian> StudentGuardians { get; set; } = new List<StudentGuardian>();
    // public int? MainStudentGuardianId { get; set; } // Optional
    // public StudentGuardian MainStudentGuardian { get; set; } // Navigation property for Main StudentGuardian (optional)
}
