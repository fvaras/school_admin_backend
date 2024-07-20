using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Authorize]
[Route("api/planning")]
public class PlanningController : ControllerBase
{
    private readonly IPlanningService _planningService;

    public PlanningController(
        IPlanningService planningService
        )
    {
        _planningService = planningService;
    }

    [HttpPost]
    public async Task<PlanningTableRowDTO> Create([FromBody] PlanningForCreationDTO planningDTO)
    {
        return await _planningService.Create(planningDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<PlanningTableRowDTO> Update(Guid id, [FromBody] PlanningForUpdateDTO planningDTO)
    {
        return await _planningService.Update(id, planningDTO);
    }

    [HttpPut("withTimeBlock/{id:int}")]
    public async Task<PlanningTableRowDTO> UpdateWithTimeBlocks(Guid id, [FromBody] PlanningWithTimeBlocksForUpdateDTO planningDTO)
    {
        return await _planningService.UpdateWithTimeBlocks(id, planningDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(Guid id)
    {
        await _planningService.Delete(id);
    }

    [HttpGet("{id:int}")]
    public async Task<PlanningDTO> Retrieve(Guid id)
    {
        return await _planningService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<PlanningTableRowDTO>> RetrieveAll()
    {
        Guid teacherId = Guid.NewGuid(); // TODO: Get from token
        return await _planningService.RetrieveAll(teacherId);
    }

    [HttpGet("byGradeAndSubject/{gradeId:int}/{subjectId:int}")]
    public async Task<List<LabelValueDTO<Guid>>> RetrieveByGradeAndSubject(Guid gradeId, Guid subjectId)
    {
        // int gradeId = 1; // TODO: Get from token
        return await _planningService.RetrieveByGradeAndSubject(gradeId, subjectId);
    }

    [HttpGet("bySubjectAndTimeBlock/{subjectId:int}/{timeBlockId:int}/{dateString}")]
    public async Task<PlanningDTO> RetrievePlanningBySubjectAndTimeBlock(Guid subjectId, Guid timeBlockId, string dateString)
    {
        return await _planningService.RetrieveBySubjectTimeBlockAndDate(subjectId, timeBlockId, dateString);
    }
}