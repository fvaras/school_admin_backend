using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Guardian;

[ApiController]
[Authorize]
[Route("api/guardian/student")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly HttpContextHelper _httpContextHelper;

    public StudentController(
        IStudentService studentService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _studentService = studentService;
        _httpContextHelper = new HttpContextHelper(httpContextAccessor.HttpContext);
    }

    [HttpGet("forList")]
    public async Task<List<LabelValueDTO<Guid>>> GetStudentsByGuardianForList()
    {
        Guid guardianId = _httpContextHelper.GetUserProfileId();
        return await _studentService.GetByGuardianForList(guardianId);
    }
}
