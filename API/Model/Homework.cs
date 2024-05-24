using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Homeworks", Schema = "public")]
public class Homework
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset EndsAt { get; set; }
    public byte StateId { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}