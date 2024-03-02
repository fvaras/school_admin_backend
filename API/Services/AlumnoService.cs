using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class AlumnoService : IAlumnoService
{
    private readonly ILoggerService _logger;
    private readonly IAlumnoDAL _alumnoDAL;
    private readonly IMapper _mapper;

    public AlumnoService(
        ILoggerService logger,
        IAlumnoDAL alumnoDAL,
        IMapper mapper
        )
    {
        _logger = logger;
        _alumnoDAL = alumnoDAL;
        _mapper = mapper;
    }

    public async Task<int> Create(AlumnoForCreationDTO alumnoDTO)
    {
        Alumno alumno = _mapper.Map<Alumno>(alumnoDTO);
        alumno.CreatedAt = DateTime.Now;
        alumno.UpdatedAt = DateTime.Now;
        return await _alumnoDAL.Create(alumno);
    }

    public async Task Update(int idAlumno, AlumnoForUpdateDTO alumnoDTO)
    {
        Alumno alumno = await GetRecordAndCheckExistence(idAlumno);
        _mapper.Map(alumnoDTO, alumno);
        alumno.UpdatedAt = DateTime.Now;
        await _alumnoDAL.Update(alumno);
    }

    public async Task Delete(int idAlumno)
    {
        Alumno alumno = await GetRecordAndCheckExistence(idAlumno);
        await _alumnoDAL.Delete(alumno);
    }

    public async Task<AlumnoDTO?> Retrieve(int idAlumno) => _mapper.Map<AlumnoDTO>(await _alumnoDAL.Retrieve(idAlumno));

    public async Task<List<AlumnoDTO>> RetrieveAll() => _mapper.Map<List<AlumnoDTO>>(await _alumnoDAL.RetrieveAll());

    private async Task<Alumno> GetRecordAndCheckExistence(int idAlumno)
    {
        Alumno alumno = await _alumnoDAL.Retrieve(idAlumno);
        if (alumno is null)
            throw new EntityNotFoundException();
        return alumno;
    }
}
