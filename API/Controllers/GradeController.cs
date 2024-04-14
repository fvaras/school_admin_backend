using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Authorize]
[Route("api/grade")]
public class GradeController : ControllerBase
{
    private readonly IGradeService _gradeService;

    public GradeController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    [HttpPost]
    public async Task<GradeDTO> Create([FromBody] GradeForCreationDTO gradeDTO)
    {
        return await _gradeService.Create(gradeDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<GradeDTO> Update(int id, [FromBody] GradeForUpdateDTO gradeDTO)
    {
        return await _gradeService.Update(id, gradeDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id)
    {
        await _gradeService.Delete(id);
    }

    [HttpGet("{id:int}")]
    public async Task<GradeDTO> Retrieve(int id)
    {
        return await _gradeService.Retrieve(id);
    }

    [HttpGet("teachersId/{id:int}")]
    public async Task<List<int>> RetrieveTeachersId(int id)
    {
        return await _gradeService.RetrieveTeachersId(id);
    }

    [HttpGet]
    public async Task<List<GradeDTO>> RetrieveAll()
    {
        return await _gradeService.RetrieveAll();
    }

    [HttpGet("forList")]
    public async Task<List<LabelValueDTO<int>>> RetrieveForList()
    {
        return await _gradeService.RetrieveForList();
    }
}
