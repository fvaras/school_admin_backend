using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers.Admin;

[ApiController]
[Authorize]
[Route("api/calendarevent")]
public class CalendarEventController : ControllerBase
{
    private readonly ICalendarEventService _calendarEventService;

    public CalendarEventController(ICalendarEventService calendarEventService)
    {
        _calendarEventService = calendarEventService;
    }

    [HttpPost]
    public async Task<CalendarEventDTO> Create([FromBody] CalendarEventForCreationDTO calendarEventDTO)
    {
        return await _calendarEventService.Create(calendarEventDTO);
    }

    [HttpPut("{id:Guid}")]
    public async Task<CalendarEventDTO> Update(Guid id, [FromBody] CalendarEventForUpdateDTO calendarEventDTO)
    {
        return await _calendarEventService.Update(id, calendarEventDTO);
    }

    [HttpDelete("{id:Guid}")]
    public async Task Delete(Guid id)
    {
        await _calendarEventService.Delete(id);
    }

    [HttpGet("{id:Guid}")]
    public async Task<CalendarEventDTO> Retrieve(Guid id)
    {
        return await _calendarEventService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<CalendarEventDTO>> RetrieveAll()
    {
        return await _calendarEventService.RetrieveAll();
    }

    [HttpGet("types")]
    public List<LabelValueDTO<int>> GetEventTypes() => _calendarEventService.GetEventTypes();
}
