using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Authorize]
[Route("api/guardian")]
public class GuardianController : ControllerBase
{
    private readonly IGuardianService _guardianService;

    public GuardianController(IGuardianService guardianService)
    {
        _guardianService = guardianService;
    }

    [HttpPost]
    public async Task<GuardianTableRowDTO> Create([FromBody] GuardianForCreationDTO guardianDTO)
    {
        return await _guardianService.Create(guardianDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<GuardianTableRowDTO> Update(int id, [FromBody] GuardianForUpdateDTO guardianDTO)
    {
        return await _guardianService.Update(id, guardianDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id)
    {
        await _guardianService.Delete(id);
    }

    [HttpGet("{id:int}")]
    public async Task<GuardianDTO> Retrieve(int id)
    {
        return await _guardianService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<GuardianTableRowDTO>> RetrieveAll()
    {
        return await _guardianService.RetrieveAll();
    }

    [HttpGet("byNamesOrRut")]
    public async Task<List<GuardianTableRowDTO>> RetrieveByNamesOrRut(string text)
    {
        return await _guardianService.RetrieveByNamesOrRut(text);
    }
}
