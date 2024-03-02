using Microsoft.AspNetCore.Mvc;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Route("api/studentguardian")]
public class StudentGuardianController : ControllerBase
{
    private readonly IStudentGuardianService _studentGuardianService;

    public StudentGuardianController(IStudentGuardianService studentGuardianService)
    {
        _studentGuardianService = studentGuardianService;
    }

    [HttpPost]
    public async Task<int> Create([FromBody] StudentGuardianForCreationDTO studentGuardianDTO)
    {
        return await _studentGuardianService.Create(studentGuardianDTO);
    }

    [HttpPut("{id:int}")]
    public async Task Update(int id, [FromBody] StudentGuardianForUpdateDTO studentGuardianDTO)
    {
        await _studentGuardianService.Update(id, studentGuardianDTO);
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
    public async Task<List<StudentGuardianDTO>> RetrieveAll()
    {
        return await _studentGuardianService.RetrieveAll();
    }
}
