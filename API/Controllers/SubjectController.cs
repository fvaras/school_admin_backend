using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Authorize]
[Route("api/subject")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpPost]
    public async Task<SubjectTableRowDTO> Create([FromBody] SubjectForCreationDTO subjectDTO)
    {
        return await _subjectService.Create(subjectDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<SubjectTableRowDTO> Update(int id, [FromBody] SubjectForUpdateDTO subjectDTO)
    {
        return await _subjectService.Update(id, subjectDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id)
    {
        await _subjectService.Delete(id);
    }

    [HttpGet("{id:int}")]
    public async Task<SubjectDTO> Retrieve(int id)
    {
        return await _subjectService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<SubjectTableRowDTO>> RetrieveAll()
    {
        return await _subjectService.RetrieveAll();
    }
}