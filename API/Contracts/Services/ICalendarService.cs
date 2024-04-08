using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface ICalendarService
{
    Task<int> Create(CalendarForCreationDTO calendarDTO);
    Task Update(int id, CalendarForUpdateDTO calendarDTO);
    Task Delete(int id);
    Task<CalendarDTO?> Retrieve(int id);
    Task<List<CalendarDTO>> RetrieveAll();
}
