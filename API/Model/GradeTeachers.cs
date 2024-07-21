using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("GradeTeachers", Schema = "public")]
public class GradeTeacher
{
    public Guid GradeId { get; set; }
    public Grade Grade { get; set; }

    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public byte Order { get; set; }
}
