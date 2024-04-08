namespace school_admin_api.Contracts.DTO;

public class CalendarEventBaseDTO
{
    public string Title { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public int Type { get; init; }
    public string Details { get; init; }
    public byte StateId { get; init; }
    public int CalendarId { get; init; }
}

public class CalendarEventForCreationDTO : CalendarEventBaseDTO
{
}

public class CalendarEventForUpdateDTO : CalendarEventBaseDTO
{
}

public class CalendarEventDTO : CalendarEventBaseDTO
{
    public int Id { get; init; }
}
