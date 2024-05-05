using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("TimeBlocks", Schema = "public")]
public class TimeBlock
{
    public enum ACADEMIC_WEEK_DAY
    {
        MONDAY = 1,
        TUESDAY = 2,
        WEDNESDAY = 3,
        THURSDAY = 4,
        FRIDAY = 5,
        SATURDAY = 6,
        SUNDAY = 7,
    }

    public int Id { get; set; }
    public int Year { get; set; }
    public byte Day { get; set; } // ACADEMIC_WEEK_DAY
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }
    public bool IsRecess { get; set; }
    public string BlockName { get; set; }

    public string? Color { get; set; }

    public int GradeId { get; set; }
    public Grade Grade { get; set; }

    public int? SubjectId { get; set; }
    public Subject? Subject { get; set; }
}
