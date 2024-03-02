using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Courses", Schema = "public")]
public class Course
{
    [Column("Id")]
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public byte Capacity { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
