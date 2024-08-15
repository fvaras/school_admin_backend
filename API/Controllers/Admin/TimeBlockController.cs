using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Admin;

[Authorize]
[ApiController]
[Route("api/timeblock")]
public class TimeBlockController : ControllerBase
{
    private readonly ITimeBlockService _timeBlockService;
    private readonly HttpContextHelper _httpContextHelper;

    public TimeBlockController(
        ITimeBlockService timeBlockService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _timeBlockService = timeBlockService;
        _httpContextHelper = new HttpContextHelper(httpContextAccessor.HttpContext);
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
        Guid teacherId = _httpContextHelper.GetUserProfileId();
        return await _timeBlockService.RetrieveAll(gradeId, teacherId);
    }

    [HttpPost("weeklyBlocksBase")]
    public async Task CreateWeeklyBlocksBase()
    {
        Guid gradeId = Guid.Parse("f76b8fda-4cad-4141-a9fc-b3551871705b"); // TODO: Get from tkn or session
        await _timeBlockService.CreateAllWeekTimeBlocksBase(gradeId);
    }
}