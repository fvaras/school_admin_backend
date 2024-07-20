using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ICalendarService
{
    Task<Guid> Create(CalendarForCreationDTO calendarDTO);
    Task Update(Guid id, CalendarForUpdateDTO calendarDTO);
    Task Delete(Guid id);
    Task<CalendarDTO?> Retrieve(Guid id);
    Task<List<CalendarDTO>> RetrieveAll();
}
