using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Student;

[ApiController]
[Authorize]
[Route("api/student/subject")]
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

    [HttpGet("list")]
    public async Task<List<LabelValueDTO<Guid>>> RetrieveWithGradeByStudentForList()
    {
        Guid studentId = _httpContextHelper.GetUserProfileId();
        return await _subjectService.RetrieveForListByStudent(studentId);
    }
}
