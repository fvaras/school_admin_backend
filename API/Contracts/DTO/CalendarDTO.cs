namespace school_admin_api.Contracts.DTO;

public class CalendarBaseDTO
{
    public string Title { get; init; }
    public byte StateId { get; init; }
}

public class CalendarForCreationDTO : CalendarBaseDTO
{
}

public class CalendarForUpdateDTO : CalendarBaseDTO
{
}

public class CalendarDTO : CalendarBaseDTO
{
    public int Id { get; init; }
    // Include CalendarEvents here if necessary, represented as DTOs
}
