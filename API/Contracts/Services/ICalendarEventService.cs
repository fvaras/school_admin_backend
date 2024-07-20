using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ICalendarEventService
{
    Task<CalendarEventDTO> Create(CalendarEventForCreationDTO calendarEventDTO);
    Task<CalendarEventDTO> Update(Guid idCalendarEvent, CalendarEventForUpdateDTO calendarEventDTO);
    Task Delete(Guid idCalendarEvent);
    Task<CalendarEventDTO?> Retrieve(Guid idCalendarEvent);
    Task<List<CalendarEventDTO>> RetrieveAll();

    List<LabelValueDTO<int>> GetEventTypes();
}
