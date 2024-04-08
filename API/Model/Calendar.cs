using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Calendars", Schema = "public")]
public class Calendar
{
    [Column("Id")]
    public int Id { get; set; }
    public string Title { get; set; }
    public byte StateId { get; set; }
    public ICollection<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();

    public enum CALENDAR_STATES
    {
        ACTIVE = 1,
        INACTIVE = 2,
    }
}
