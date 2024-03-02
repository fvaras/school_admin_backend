using Microsoft.AspNetCore.Mvc;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Route("api/course")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost]
    public async Task<int> Create([FromBody] CourseForCreationDTO courseDTO)
    {
        return await _courseService.Create(courseDTO);
    }

    [HttpPut("{id:int}")]
    public async Task Update(int id, [FromBody] CourseForUpdateDTO courseDTO)
    {
        await _courseService.Update(id, courseDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id)
    {
        await _courseService.Delete(id);
    }

    [HttpGet("{id:int}")]
    public async Task<CourseDTO> Retrieve(int id)
    {
        return await _courseService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<CourseDTO>> RetrieveAll()
    {
        return await _courseService.RetrieveAll();
    }
}
