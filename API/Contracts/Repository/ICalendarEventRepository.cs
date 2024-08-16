using school_admin_api.Model;

namespace school_admin_api.Contracts.Repository;

public interface ICalendarEventRepository
{
    Task<Guid> Create(CalendarEvent calendarEvent);
    Task Update(CalendarEvent calendarEvent);
    Task Delete(CalendarEvent calendarEvent);
    Task<CalendarEvent?> Retrieve(Guid idCalendarEvent, bool trackChanges = false);
    Task<List<CalendarEvent>> RetrieveAll();
}
