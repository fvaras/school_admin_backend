using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface IAlumnoDAL
{
    Task<int> Create(Alumno alumno);
    Task Update(Alumno alumno);
    Task Delete(Alumno alumno);
    Task<Alumno?> Retrieve(int idAlumno, bool trackChanges = false);
    Task<List<Alumno>> RetrieveAll();
}
