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
    public async Task<StudentTableRowDTO> Create([FromBody] StudentForCreationDTO studentDTO)
    {
        return await _studentService.Create(studentDTO);
    }

    [HttpPut("{id:Guid}")]
    public async Task<StudentTableRowDTO> Update(Guid id, [FromBody] StudentForUpdateDTO studentDTO)
    {
        return await _studentService.Update(id, studentDTO);
    }

    [HttpDelete("{id:Guid}")]
    public async Task Delete(Guid id)
    {
        await _studentService.Delete(id);
    }

    [HttpGet("{id:Guid}")]
    public async Task<StudentDTO> Retrieve(Guid id)
    {
        return await _studentService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<StudentTableRowDTO>> RetrieveAll()
    {
        return await _studentService.RetrieveAll();
    }
}
