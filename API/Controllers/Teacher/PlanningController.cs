using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Teacher;

[ApiController]
[Authorize]
[Route("api/teacher/planning")]
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

    [HttpPost]
    public async Task<Guid> Create([FromBody] PlanningForCreationDTO planningDTO)
    {
        return await _planningService.Create(planningDTO);
    }

    [HttpPut("{id:Guid}")]
    public async Task<PlanningTableRowDTO> Update(Guid id, [FromBody] PlanningForUpdateDTO planningDTO)
    {
        return await _planningService.Update(id, planningDTO);
    }

    [HttpPut("withTimeBlock/{id:Guid}")]
    public async Task<PlanningTableRowDTO> UpdateWithTimeBlocks(Guid id, [FromBody] PlanningWithTimeBlocksForUpdateDTO planningDTO)
    {
        return await _planningService.UpdateWithTimeBlocks(id, planningDTO);
    }

    [HttpDelete("{id:Guid}")]
    public async Task Delete(Guid id)
    {
        await _planningService.Delete(id);
    }

    [HttpGet("{id:Guid}")]
    public async Task<PlanningDTO> Retrieve(Guid id)
    {
        return await _planningService.Retrieve(id);
    }

    [HttpGet("bySubject/{subjectId}")]
    public async Task<List<PlanningTableRowDTO>> RetrieveAllByTeacherAndSubject(Guid subjectId)
    {
        Guid teacherId = _httpContextHelper.GetUserProfileId();
        return await _planningService.RetrieveAllByTeacherAndSubject(
            teacherId: teacherId,
            subjectId: subjectId
        );
    }

    [HttpGet("byGradeAndSubject/{gradeId:int}/{subjectId:int}")]
    public async Task<List<LabelValueDTO<Guid>>> RetrieveByGradeAndSubject(Guid gradeId, Guid subjectId)
    {
        // int gradeId = 1; // TODO: Get from token
        return await _planningService.RetrieveByGradeAndSubjectForList(gradeId, subjectId);
    }

    // [HttpGet("bySubjectAndTimeBlock/{subjectId:int}/{timeBlockId:int}/{dateString}")]
    // public async Task<PlanningDTO> RetrievePlanningBySubjectAndTimeBlock(Guid subjectId, Guid timeBlockId, string dateString)
    // {
    //     return await _planningService.RetrieveBySubjectTimeBlockAndDate(subjectId, timeBlockId, dateString);
    // }
}