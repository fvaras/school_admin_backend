namespace school_admin_api.Contracts.DTO;

public class GradeBaseDTO
{
    public string Name { get; init; }
    public string ContactEmail { get; init; }
    public string ContactPhone { get; init; }
    public byte Capacity { get; init; }
    public string Description { get; init; }
    public bool Active { get; init; }
}

public class GradeForCreationDTO : GradeBaseDTO
{
}

public class GradeForUpdateDTO : GradeBaseDTO
{
}

public class GradeDTO : GradeBaseDTO
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}
