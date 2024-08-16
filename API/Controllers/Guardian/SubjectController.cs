using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Guardian;

[ApiController]
[Authorize]
[Route("api/guardian/subject")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;
    private readonly HttpContextHelper _httpContextHelper;

    public SubjectController(
        ISubjectService subjectService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _subjectService = subjectService;
        _httpContextHelper = new HttpContextHelper(httpContextAccessor.HttpContext);
    }

    [HttpGet("{studentId}/list")]
    public async Task<List<LabelValueDTO<Guid>>> RetrieveForListByGuardianAndStudent([FromRoute] Guid studentId)
    {
        Guid guardianId = _httpContextHelper.GetUserProfileId();
        return await _subjectService.RetrieveForListByGuardianAndStudent(
            guardianId: guardianId,
            studentId: studentId
            );
    }
}
