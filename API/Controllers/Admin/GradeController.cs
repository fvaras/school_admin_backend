using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Admin;

[ApiController]
[Authorize]
[Route("api/grade")]
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

    [HttpPost]
    public async Task<GradeDTO> Create([FromBody] GradeForCreationDTO gradeDTO)
    {
        return await _gradeService.Create(gradeDTO);
    }

    [HttpPut("{id}")]
    public async Task<GradeDTO> Update([FromRoute] Guid id, [FromBody] GradeForUpdateDTO gradeDTO)
    {
        return await _gradeService.Update(id, gradeDTO);
    }

    [HttpDelete("{id}")]
    public async Task Delete(Guid id)
    {
        await _gradeService.Delete(id);
    }

    [HttpGet("{id}")]
    public async Task<GradeDTO> Retrieve(Guid id)
    {
        return await _gradeService.Retrieve(id);
    }

    [HttpGet("teachersId/{id}")]
    public async Task<List<Guid>> RetrieveTeachersId(Guid id)
    {
        return await _gradeService.RetrieveTeachersId(id);
    }

    [HttpGet]
    public async Task<List<GradeDTO>> RetrieveAll()
    {
        return await _gradeService.RetrieveAll();
    }

    [HttpGet("forList")]
    public async Task<List<LabelValueDTO<Guid>>> RetrieveForList()
    {   
        return await _gradeService.RetrieveForList();
    }

}
