using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Student;

[ApiController]
[Authorize]
[Route("api/student/planning")]
public class PlanningController : ControllerBase
{
    private readonly IPlanningService _planningService;
    private readonly HttpContextHelper _httpContextHelper;

    public PlanningController(
        IPlanningService planningService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _planningService = planningService;
        _httpContextHelper = new HttpContextHelper(httpContextAccessor.HttpContext);
    }

    [HttpGet("{subjectId}")]
    public async Task<List<PlanningTableRowDTO>> RetrieveBySubjectForGuardianMainTable(Guid subjectId)
    {
        Guid studentId = _httpContextHelper.GetUserProfileId();
        return await _planningService.RetrieveAllByStudentAndSubject(
                studentId: studentId,
                subjectId: subjectId
            );
    }

    // [HttpGet("bySubjectAndTimeBlock/{subjectId:int}/{timeBlockId:int}/{dateString}")]
    // public async Task<PlanningDTO> RetrievePlanningBySubjectAndTimeBlock(Guid subjectId, Guid timeBlockId, string dateString)
    // {
    //     return await _planningService.RetrieveBySubjectTimeBlockAndDate(subjectId, timeBlockId, dateString);
    // }
}