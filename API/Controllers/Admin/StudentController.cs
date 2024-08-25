using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Admin;

[ApiController]
[Authorize]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly HttpContextHelper _httpContextHelper;

    public StudentController(
        IStudentService studentService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _studentService = studentService;
        _httpContextHelper = new HttpContextHelper(httpContextAccessor.HttpContext);
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
        return await _studentService.RetrieveWithGuardians(id);
    }

    [HttpGet]
    public async Task<List<StudentTableRowDTO>> RetrieveAll()
    {
        return await _studentService.RetrieveAll();
    }

    // [HttpGet("byGuardianForList")]
    // public async Task<List<LabelValueDTO<Guid>>> GetStudentsByGuardianForList()
    // {
    //     Guid guardianId = _httpContextHelper.GetUserProfileId();
    //     return await _studentService.GetByGuardianForList(guardianId);
    // }
}
