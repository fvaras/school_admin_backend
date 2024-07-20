using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Authorize]
[Route("api/calendar")]
public class CalendarController : ControllerBase
{
    private readonly ICalendarService _calendarService;

    public CalendarController(ICalendarService calendarService)
    {
        _calendarService = calendarService;
    }

    [HttpPost]
    public async Task<Guid> Create([FromBody] CalendarForCreationDTO calendarDTO)
    {
        return await _calendarService.Create(calendarDTO);
    }

    [HttpPut("{id:int}")]
    public async Task Update(Guid id, [FromBody] CalendarForUpdateDTO calendarDTO)
    {
        await _calendarService.Update(id, calendarDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(Guid id)
    {
        await _calendarService.Delete(id);
    }

    [HttpGet("{id:int}")]
    public async Task<CalendarDTO> Retrieve(Guid id)
    {
        return await _calendarService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<CalendarDTO>> RetrieveAll()
    {
        return await _calendarService.RetrieveAll();
    }
}
