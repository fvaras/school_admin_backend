using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Teacher;

[Route("api/teacher/grade")]
[Authorize]
[ApiController]
public class GradeController : ControllerBase
{
    private readonly IGradeService _gradeService;
    private readonly HttpContextHelper _httpContextHelper;

    public GradeController(
        IGradeService gradeService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _gradeService = gradeService;
        _httpContextHelper = new HttpContextHelper(httpContextAccessor.HttpContext);
    }

    // [HttpGet("list")]
    // public async Task<List<LabelValueDTO<Guid>>> getGradesByTeacherForList()
    // {
    //     Guid teacherId = _httpContextHelper.GetUserProfileId();
    //     return await _gradeService.RetrieveByTeacherForList(teacherId);
    // }

    [HttpGet("byMain/list")]
    public async Task<List<LabelValueDTO<Guid>>> getGradesByMainTeacherForList()
    {
        Guid teacherId = _httpContextHelper.GetUserProfileId();
        return await _gradeService.RetrieveByMainTeacherForList(teacherId);
    }
}