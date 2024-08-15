using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Admin;

[Authorize]
[ApiController]
[Route("api/homework")]
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
    public async Task<HomeworkTableRowDTO> Create([FromBody] HomeworkForCreationDTO homeworkDTO)
    {
        return await _homeworkService.Create(homeworkDTO);
    }

    [HttpPut("{id}")]
    public async Task<HomeworkTableRowDTO> Update(Guid id, [FromBody] HomeworkForUpdateDTO homeworkDTO)
    {
        return await _homeworkService.Update(id, homeworkDTO);
    }

    [HttpDelete("{id}")]
    public async Task Delete(Guid id)
    {
        await _homeworkService.Delete(id);
    }

    [HttpGet("{id}")]
    public async Task<HomeworkDTO> Retrieve(Guid id)
    {
        return await _homeworkService.Retrieve(id);
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
