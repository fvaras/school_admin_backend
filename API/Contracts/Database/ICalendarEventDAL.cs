using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface ICalendarEventDAL
{
    Task<Guid> Create(CalendarEvent calendarEvent);
    Task Update(CalendarEvent calendarEvent);
    Task Delete(CalendarEvent calendarEvent);
    Task<CalendarEvent?> Retrieve(Guid idCalendarEvent, bool trackChanges = false);
    Task<List<CalendarEvent>> RetrieveAll();
}
