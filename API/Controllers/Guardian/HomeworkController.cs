using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Guardian;

[Authorize]
[ApiController]
[Route("api/guardian/homework")]
public class HomeworkController : ControllerBase
{
    private readonly IHomeworkService _homeworkService;
    private readonly HttpContextHelper _httpContextHelper;

    public HomeworkController(
        IHomeworkService homeworkService,
        IHttpContextAccessor httpContextAccessor
        )
    {
        _homeworkService = homeworkService;
        _httpContextHelper = new HttpContextHelper(httpContextAccessor.HttpContext);
    }

    [HttpGet("guardian/{studentId}/{subjectId}")]
    public async Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForGuardianMainTable(Guid studentId, Guid subjectId)
    {
        Guid guardianId = _httpContextHelper.GetUserProfileId();
        return await _homeworkService.RetrieveBySubjectForGuardianMainTable(
            guardianId: guardianId,
            studentId: studentId,
            subjectId: subjectId);
    }
}
