namespace school_admin_api.Contracts.DTO;

public class HomeworkBaseDTO
{
    public string Title { get; init; }
    public string Description { get; init; } = string.Empty;
    public DateTime EndsAt { get; init; }
    public byte StateId { get; set; }
    public Guid SubjectId { get; init; }
}

public class HomeworkForCreationDTO : HomeworkBaseDTO
{
}

public class HomeworkForUpdateDTO : HomeworkBaseDTO
{
    public Guid Id { get; init; }
}

public class HomeworkDTO : HomeworkBaseDTO
{
    public Guid Id { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset UpdatedAt { get; init; }
}

public class HomeworkTableRowDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset EndsAt { get; set; }
    public byte StateId { get; set; }
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
    public Guid GradeId { get; set; }
    public string GradeName { get; set; }
}
