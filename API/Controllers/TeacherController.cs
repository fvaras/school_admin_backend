using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Route("api/teacher")]
[Authorize]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpPost]
    public async Task<int> Create([FromBody] TeacherForCreationDTO teacherDTO)
    {
        return await _teacherService.Create(teacherDTO);
    }

    [HttpPut("{id:int}")]
    public async Task Update(int id, [FromBody] TeacherForUpdateDTO teacherDTO)
    {
        await _teacherService.Update(id, teacherDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id)
    {
        await _teacherService.Delete(id);
    }

    [HttpGet("{id:int}")]
    public async Task<TeacherDTO> Retrieve(int id)
    {
        return await _teacherService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<TeacherDTO>> RetrieveAll()
    {
        return await _teacherService.RetrieveAll();
    }

    [HttpGet("forList")]
    public async Task<List<LabelValueDTO<int>>> RetrieveForList()
    {
        return await _teacherService.RetrieveForList();
    }
}
