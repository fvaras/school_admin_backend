using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ICalendarEventService
{
    Task<CalendarEventDTO> Create(CalendarEventForCreationDTO calendarEventDTO);
    Task<CalendarEventDTO> Update(int idCalendarEvent, CalendarEventForUpdateDTO calendarEventDTO);
    Task Delete(int idCalendarEvent);
    Task<CalendarEventDTO?> Retrieve(int idCalendarEvent);
    Task<List<CalendarEventDTO>> RetrieveAll();

    List<LabelValueDTO<int>> GetEventTypes();
}
