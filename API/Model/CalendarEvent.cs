using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("CalendarEvents", Schema = "public")]
public class CalendarEvent
{
    [Column("Id")]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public int EventType { get; set; }
    public string Details { get; set; }
    public byte StateId { get; set; }

    // Navigation Properties

    // [ForeignKey("Calendar")]
    public Guid CalendarId { get; set; }
    public Calendar Calendar { get; set; }

    // Enums for EventType and StateId
    public enum EVENT_TYPES
    {
        [Description("Vacaciones")] HOLIDAY = 1,
        [Description("Administrativo")] ADMINISTRATIVE = 2,
        [Description("Reunión")] MEETINGS = 3,
        [Description("Social")] SOCIAL = 4,
        [Description("Otros")] OTHERS = 9
    }

    public enum CALENDAR_EVENT_STATES
    {
        ACTIVE = 1,
        INACTIVE = 2,
    }
}
