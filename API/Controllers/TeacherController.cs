using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Authorize]
[Route("api/teacher")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpPost]
    public async Task<TeacherTableRowDTO> Create([FromBody] TeacherForCreationDTO teacherDTO)
    {
        return await _teacherService.Create(teacherDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<TeacherTableRowDTO> Update(Guid id, [FromBody] TeacherForUpdateDTO teacherDTO)
    {
        return await _teacherService.Update(id, teacherDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(Guid id)
    {
        await _teacherService.Delete(id);
    }

    [HttpGet("{id:int}")]
    public async Task<TeacherDTO> Retrieve(Guid id)
    {
        return await _teacherService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<TeacherTableRowDTO>> RetrieveAll()
    {
        return await _teacherService.RetrieveAll();
    }

    [HttpGet("forList")]
    public async Task<List<LabelValueDTO<Guid>>> RetrieveForList()
    {
        return await _teacherService.RetrieveForList();
    }

    [HttpGet("byNamesOrRut")]
    public async Task<List<UserDerivedEntityDataForLists<int>>> RetrieveByNamesOrRut(string? text)
    {
        text = string.IsNullOrWhiteSpace(text) ? string.Empty : text.Trim();
        return await _teacherService.RetrieveByNamesOrRut(text);
    }
}
