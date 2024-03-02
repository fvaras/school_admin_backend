namespace school_admin_api.Contracts.DTO;

public class MyEntityBaseDTO
{
    public string Rut { get; init; }
    public short Codigo { get; init; }
    public string Cuenta { get; init; }
}

public class MyEntityForCreationDTO : MyEntityBaseDTO
{
}

public class MyEntityForUpdateDTO : MyEntityBaseDTO
{
    // public int IdMyEntity { get; init; }
}

public class MyEntityDTO : MyEntityBaseDTO
{
    public int IdMyEntity { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}