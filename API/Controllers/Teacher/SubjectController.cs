using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Teacher;

[ApiController]
[Authorize]
[Route("api/teacher/subject")]
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

    [HttpGet("")]
    public async Task<List<PKFKPair<Guid, Guid>>> RetrieveWithGradeByTeacherForList()
    {
        Guid teacherId = _httpContextHelper.GetUserProfileId();
        return await _subjectService.RetrieveWithGradeByTeacherForList(teacherId);
    }

    [HttpGet("grade/{gradeId}/list")]
    public async Task<List<LabelValueDTO<Guid>>> RetrieveByMainTeacherForList(Guid gradeId)
    {
        Guid teacherId = _httpContextHelper.GetUserProfileId();
        return await _subjectService.RetrieveByMainTeacherForList(teacherId, gradeId: gradeId);
    }
}
