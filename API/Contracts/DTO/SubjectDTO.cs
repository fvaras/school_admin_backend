namespace school_admin_api.Contracts.DTO;

public class SubjectBaseDTO
{
    public string Name { get; init; }
    public string? Color { get; set; }
    public Guid GradeId { get; init; }
    public Guid TeacherId { get; init; }
    public int StateId { get; init; }
}

public class SubjectForCreationDTO : SubjectBaseDTO
{
}

public class SubjectForUpdateDTO : SubjectBaseDTO
{
}

public class SubjectDTO : SubjectBaseDTO
{
    public Guid Id { get; init; }
}
