using school_admin_api.Contracts.DTO;

namespace school_admin_api.Contracts.Services;

public interface IAlumnoService
{
    Task<int> Create(AlumnoForCreationDTO alumnoDTO);
    Task Update(int idAlumno, AlumnoForUpdateDTO alumnoDTO);
    Task Delete(int idAlumno);
    Task<AlumnoDTO?> Retrieve(int idAlumno);
    Task<List<AlumnoDTO>> RetrieveAll();
}
