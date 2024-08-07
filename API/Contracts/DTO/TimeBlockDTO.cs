namespace school_admin_api.Contracts.DTO;

public class TimeBlockBaseDTO
{
    public int? Year { get; set; }
    public byte Day { get; init; }
    public string Start { get; init; }
    public string End { get; init; }
    public bool IsRecess { get; init; }
    public string BlockName { get; set; }
    public string? Color { get; set; }
    public Guid? SubjectId { get; set; }
}

public class TimeBlockForCreationDTO : TimeBlockBaseDTO
{
    public Guid? GradeId { get; set; }
}

public class TimeBlockForUpdateDTO : TimeBlockBaseDTO
{
}

public class TimeBlockDTO : TimeBlockBaseDTO
{
    public Guid Id { get; init; }
    public Guid? GradeId { get; set; }
}

public class TimeBlockTableRowDTO
{
    public Guid Id { get; init; }
    public int Year { get; init; }
    public byte Day { get; init; }
    public TimeSpan Start { get; init; }
    public TimeSpan End { get; init; }
    public bool IsRecess { get; init; }
    public string BlockName { get; set; }
    public string? Color { get; set; }

    public Guid GradeId { get; set; }
    // public Grade Grade { get; set; }

    // public Subject? Subject { get; set; }
    public Guid? SubjectId { get; set; }
}