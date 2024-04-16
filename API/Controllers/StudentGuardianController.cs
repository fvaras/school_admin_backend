using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Route("api/studentguardian")]
[Authorize]
public class StudentGuardianController : ControllerBase
{
    private readonly IStudentGuardianService _studentGuardianService;

    public StudentGuardianController(IStudentGuardianService studentGuardianService)
    {
        _studentGuardianService = studentGuardianService;
    }

    [HttpPost]
    public async Task<StudentGuardianTableRowDTO> Create([FromBody] StudentGuardianForCreationDTO studentGuardianDTO)
    {
        return await _studentGuardianService.Create(studentGuardianDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<StudentGuardianTableRowDTO> Update(int id, [FromBody] StudentGuardianForUpdateDTO studentGuardianDTO)
    {
        return await _studentGuardianService.Update(id, studentGuardianDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id)
    {
        await _studentGuardianService.Delete(id);
    }

    [HttpGet("{id:int}")]
    public async Task<StudentGuardianDTO> Retrieve(int id)
    {
        return await _studentGuardianService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<StudentGuardianTableRowDTO>> RetrieveAll()
    {
        return await _studentGuardianService.RetrieveAll();
    }
}
