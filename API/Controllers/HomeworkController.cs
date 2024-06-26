using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[Authorize]
[ApiController]
[Route("api/homework")]
public class HomeworkController : ControllerBase
{
    private readonly IHomeworkService _homeworkService;

    public HomeworkController(
        IHomeworkService homeworkService
        )
    {
        _homeworkService = homeworkService;
    }

    [HttpPost]
    public async Task<HomeworkTableRowDTO> Create([FromBody] HomeworkForCreationDTO homeworkDTO)
    {
        return await _homeworkService.Create(homeworkDTO);
    }

    [HttpPut("{id}")]
    public async Task<HomeworkTableRowDTO> Update(Guid id, [FromBody] HomeworkForUpdateDTO homeworkDTO)
    {
        return await _homeworkService.Update(id, homeworkDTO);
    }

    [HttpDelete("{id}")]
    public async Task Delete(Guid id)
    {
        await _homeworkService.Delete(id);
    }

    [HttpGet("{id}")]
    public async Task<HomeworkDTO> Retrieve(Guid id)
    {
        return await _homeworkService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<HomeworkTableRowDTO>> RetrieveAll()
    {
        return await _homeworkService.RetrieveAll();
    }
}
