using Microsoft.AspNetCore.Mvc;
using school_admin_api.ActionFilters;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;
using school_admin_api.Helpers;

namespace school_admin_api.Controllers.Admin;

[ApiController]
[Authorize]
[Route("api/subject")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;
    private readonly HttpContextHelper _httpContextHelper;

    public SubjectController(
        ISubjectService subjectService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _subjectService = subjectService;
        _httpContextHelper = new HttpContextHelper(httpContextAccessor.HttpContext);
    }

    [HttpPost]
    public async Task<SubjectTableRowDTO> Create([FromBody] SubjectForCreationDTO subjectDTO)
    {
        return await _subjectService.Create(subjectDTO);
    }

    [HttpPut("{id:Guid}")]
    public async Task<SubjectTableRowDTO> Update(Guid id, [FromBody] SubjectForUpdateDTO subjectDTO)
    {
        return await _subjectService.Update(id, subjectDTO);
    }

    [HttpDelete("{id:Guid}")]
    public async Task Delete(Guid id)
    {
        await _subjectService.Delete(id);
    }

    [HttpGet("{id:Guid}")]
    public async Task<SubjectDTO> Retrieve(Guid id)
    {
        return await _subjectService.Retrieve(id);
    }

    [HttpGet]
    public async Task<List<SubjectTableRowDTO>> RetrieveAll()
    {
        return await _subjectService.RetrieveAll();
    }

    // [HttpGet("byGradeForList")]
    // public async Task<List<LabelValueDTO<Guid>>> RetrieveForList()
    // {
    //     int gradeId = 1; // TODO: Get from tkn or session
    //     return await _subjectService.RetrieveByGrade(gradeId);
    // }    
}
