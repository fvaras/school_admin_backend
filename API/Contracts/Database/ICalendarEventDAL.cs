using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface ICalendarEventDAL
{
    Task<int> Create(CalendarEvent calendarEvent);
    Task Update(CalendarEvent calendarEvent);
    Task Delete(CalendarEvent calendarEvent);
    Task<CalendarEvent?> Retrieve(int idCalendarEvent, bool trackChanges = false);
    Task<List<CalendarEvent>> RetrieveAll();
}
