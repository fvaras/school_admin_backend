namespace school_admin_api.Contracts.DTO;

public class CalendarEventBaseDTO
{
    public string Title { get; init; }
    public DateTimeOffset StartDate { get; init; }
    public DateTimeOffset EndDate { get; init; }
    public int Type { get; init; }
    public string Details { get; init; }
    public byte StateId { get; init; }
    public Guid CalendarId { get; init; }
}

public class CalendarEventForCreationDTO : CalendarEventBaseDTO
{
    public string StartISODate { get; init; }
    public string EndISODate { get; init; }
}

public class CalendarEventForUpdateDTO : CalendarEventBaseDTO
{
    public string StartISODate { get; init; }
    public string EndISODate { get; init; }
}

public class CalendarEventDTO : CalendarEventBaseDTO
{
    public Guid Id { get; init; }
}
