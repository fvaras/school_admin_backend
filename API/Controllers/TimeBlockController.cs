using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[Authorize]
[ApiController]
[Route("api/timeblock")]
public class TimeBlockController : ControllerBase
{
    private readonly ITimeBlockService _timeBlockService;

    public TimeBlockController(
        ITimeBlockService timeBlockService
        )
    {
        _timeBlockService = timeBlockService;
    }

    [HttpPost]
    public async Task<TimeBlockTableRowDTO> Create([FromBody] TimeBlockForCreationDTO timeBlockDTO)
    {
        timeBlockDTO.Year = DateTimeOffset.UtcNow.Year; // TODO: Configure current Year Operation
        return await _timeBlockService.Create(timeBlockDTO);
    }

    [HttpPut("{id:Guid}")]
    public async Task<TimeBlockTableRowDTO> Update(Guid id, [FromBody] TimeBlockForUpdateDTO timeBlockDTO)
    {
        timeBlockDTO.Year = DateTimeOffset.UtcNow.Year; // TODO: Configure current Year Operation
        return await _timeBlockService.Update(id, timeBlockDTO);
    }

    [HttpDelete("{id:Guid}")]
    public async Task Delete(Guid id)
    {
        await _timeBlockService.Delete(id);
    }

    [HttpGet("{id:Guid}")]
    public async Task<TimeBlockDTO> Retrieve(Guid id)
    {
        return await _timeBlockService.Retrieve(id);
    }

    [HttpGet("byGrade/{gradeId}")]
    public async Task<List<TimeBlockTableRowDTO>> RetrieveAll(Guid gradeId)
    {
        Guid teacherId = Guid.NewGuid(); // TODO: Get from tkn or session
        return await _timeBlockService.RetrieveAll(gradeId, teacherId);
    }

    [HttpPost("weeklyBlocksBase")]
    public async Task CreateWeeklyBlocksBase()
    {
        Guid gradeId = Guid.NewGuid(); // TODO: Get from tkn or session
        await _timeBlockService.CreateAllWeekTimeBlocksBase(gradeId);
    }
}