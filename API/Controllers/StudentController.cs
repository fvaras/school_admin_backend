using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Authorize]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(
        IStudentService studentService
        )
    {
        _studentService = studentService;
    }

    [HttpPost]
    public async Task<int> Create([FromBody] StudentForCreationDTO studentDTO)
    {
        return await _studentService.Create(studentDTO);
    }

    [HttpPut("{id:int}")]
    public async Task Update(int id, [FromBody] StudentForUpdateDTO studentDTO)
    {
        await _studentService.Update(id, studentDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id)
    {
        await _studentService.Delete(id);
    }

    [HttpGet("{id:int}")]
    public async Task<StudentDTO> Retrieve(int id)
    {
        return await _studentService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<StudentDTO>> RetrieveAll()
    {
        return await _studentService.RetrieveAll();
    }
}
