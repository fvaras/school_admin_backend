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

public class GradeForManipulationDTO : GradeBaseDTO
{
    public List<Guid> TeachersId { get; set; }
}

public class GradeForCreationDTO : GradeForManipulationDTO
{
}

public class GradeForUpdateDTO : GradeForManipulationDTO
{
}

public class GradeDTO : GradeBaseDTO
{
    public Guid Id { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; init; }
}
