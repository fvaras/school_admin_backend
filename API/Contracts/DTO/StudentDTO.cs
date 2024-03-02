namespace school_admin_api.Contracts.DTO;

public class StudentBaseDTO
{
    public string Rut { get; init; }
    public string Nombre { get; init; }
    public int? IdCurso { get; init; }
    public int IdEstado { get; init; }
}

public class StudentForCreationDTO : StudentBaseDTO
{
}

public class StudentForUpdateDTO : StudentBaseDTO
{
}

public class StudentDTO : StudentBaseDTO
{
    public int StudentId { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}
