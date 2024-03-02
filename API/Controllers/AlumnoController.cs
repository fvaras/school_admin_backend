using Microsoft.AspNetCore.Mvc;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Services;

namespace school_admin_api.Controllers;

[ApiController]
[Route("api/alumno")]
public class AlumnoController : ControllerBase
{
    private readonly IAlumnoService _alumnoService;

    public AlumnoController(
        IAlumnoService alumnoService
        )
    {
        _alumnoService = alumnoService;
    }

    [HttpPost]
    public async Task<int> Create([FromBody] AlumnoForCreationDTO alumnoDTO)
    {
        return await _alumnoService.Create(alumnoDTO);
    }

    [HttpPut("{idAlumno:int}")]
    public async Task Update(int idAlumno, [FromBody] AlumnoForUpdateDTO alumnoDTO)
    {
        await _alumnoService.Update(idAlumno, alumnoDTO);
    }

    [HttpDelete("{idAlumno:int}")]
    public async Task Delete(int idAlumno)
    {
        await _alumnoService.Delete(idAlumno);
    }

    [HttpGet("{idAlumno:int}")]
    public async Task<AlumnoDTO> Retrieve(int idAlumno)
    {
        return await _alumnoService.Retrieve(idAlumno);
    }

    [HttpGet]
    public async Task<List<AlumnoDTO>> RetrieveAll()
    {
        return await _alumnoService.RetrieveAll();
    }
}
