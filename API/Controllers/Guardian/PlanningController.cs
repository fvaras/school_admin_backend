using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Guardian;

[ApiController]
[Authorize]
[Route("api/guardian/planning")]
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

    [HttpGet("{studentId}/{subjectId}")]
    public async Task<List<PlanningTableRowDTO>> RetrieveBySubjectForGuardianMainTable(Guid studentId, Guid subjectId)
    {
        Guid guardianId = _httpContextHelper.GetUserProfileId();
        return await _planningService.RetrieveAllByGuardianAndSubject(
                guardianId: guardianId,
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