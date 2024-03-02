namespace school_admin_api.Contracts.DTO;

public class AlumnoBaseDTO
{
    public string Rut { get; init; }
    public string Nombre { get; init; }
    public int? IdCurso { get; init; }
    public int IdEstado { get; init; }
}

public class AlumnoForCreationDTO : AlumnoBaseDTO
{
}

public class AlumnoForUpdateDTO : AlumnoBaseDTO
{
}

public class AlumnoDTO : AlumnoBaseDTO
{
    public int IdAlumno { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}
