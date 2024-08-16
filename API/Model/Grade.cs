using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Grades", Schema = "public")]
public class Grade
{
    [Key]
    [Column("Id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [EmailAddress]
    [MaxLength(100)]
    public string ContactEmail { get; set; }

    [Phone]
    [MaxLength(30)]
    public string ContactPhone { get; set; }

    [Range(0, 255)]
    public byte Capacity { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public bool Active { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? UpdatedAt { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
    // public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    public ICollection<GradeTeacher> GradeTeachers { get; set; } = new List<GradeTeacher>();

    public ICollection<Subject> Subjects { get; set; } = [];
}
