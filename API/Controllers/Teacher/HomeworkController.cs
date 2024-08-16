using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Teacher;

[Authorize]
[ApiController]
[Route("api/teacher/homework")]
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

    [HttpPost]
    public async Task<Guid> Create([FromBody] HomeworkForCreationDTO homeworkDTO)
    {
        Guid teacherId = _httpContextHelper.GetUserProfileId();
        return await _homeworkService.Create(homeworkDTO, teacherId);
    }

    [HttpPut("{id}")]
    public async Task<HomeworkDTO> Update(Guid id, [FromBody] HomeworkForUpdateDTO homeworkDTO)
    {
        Guid teacherId = _httpContextHelper.GetUserProfileId();
        return await _homeworkService.Update(id, homeworkDTO, teacherId);
    }

    [HttpDelete("{id}")]
    public async Task Delete(Guid id)
    {
        Guid teacherId = _httpContextHelper.GetUserProfileId();
        await _homeworkService.Delete(id, teacherId);
    }

    [HttpGet("{id}")]
    public async Task<HomeworkDTO> Retrieve(Guid id)
    {
        return await _homeworkService.Retrieve(id);
    }

    [HttpGet("bySubject/{subjectId}")]
    public async Task<List<HomeworkTableRowDTO>> RetrieveBySubjectForTeacherMainTable(Guid subjectId)
    {
        Guid teacherId = _httpContextHelper.GetUserProfileId();
        return await _homeworkService.RetrieveBySubjectForTeacherMainTable(
            teacherId: teacherId,
            subjectId: subjectId);
    }
}
