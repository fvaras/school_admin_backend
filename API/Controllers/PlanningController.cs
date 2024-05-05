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
    public async Task<PlanningTableRowDTO> Update(int id, [FromBody] PlanningForUpdateDTO planningDTO)
    {
        return await _planningService.Update(id, planningDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id)
    {
        await _planningService.Delete(id);
    }

    [HttpGet("{id:int}")]
    public async Task<PlanningDTO> Retrieve(int id)
    {
        return await _planningService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<PlanningTableRowDTO>> RetrieveAll()
    {
        return await _planningService.RetrieveAll();
    }
}