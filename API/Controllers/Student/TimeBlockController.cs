using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Student;

[Authorize]
[ApiController]
[Route("api/student/timeblock")]
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

    [HttpGet("")]
    public async Task<List<TimeBlockTableRowDTO>> RetrieveAll()
    {
        Guid studentId = _httpContextHelper.GetUserProfileId();
        return await _timeBlockService.RetrieveAllByStudent(
            studentId: studentId
        );
    }
}