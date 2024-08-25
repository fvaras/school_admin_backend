using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Student;

[Authorize]
[ApiController]
[Route("api/student/homework")]
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

    [HttpGet("bySubject/{subjectId}")]
    public async Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForGuardianMainTable(Guid subjectId)
    {
        Guid studentId = _httpContextHelper.GetUserProfileId();
        return await _homeworkService.RetrieveBySubjectForStudentMainTable(
            studentId: studentId,
            subjectId: subjectId);
    }
}
