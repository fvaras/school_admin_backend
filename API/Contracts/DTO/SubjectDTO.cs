namespace school_admin_api.Contracts.DTO;

public class SubjectBaseDTO
{
    public string Name { get; init; }
    public int GradeId { get; init; }
    public int TeacherId { get; init; }
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
    public int Id { get; init; }
}
