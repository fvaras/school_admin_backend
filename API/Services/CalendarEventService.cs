using System.ComponentModel;
using System.Reflection;
using AutoMapper;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;
using static school_admin_api.Model.CalendarEvent;

namespace school_admin_api.Services;

public class CalendarEventService : ICalendarEventService
{
    private readonly ILoggerService _logger;
    private readonly ICalendarEventRepository _calendarEventRepository;
    private readonly ICalendarRepository _calendarRepository;
    private readonly IMapper _mapper;

    public CalendarEventService(
        ILoggerService logger,
        ICalendarEventRepository calendarEventRepository,
        ICalendarRepository calendarRepository,
        IMapper mapper)
    {
        _logger = logger;
        _calendarEventRepository = calendarEventRepository;
        _calendarRepository = calendarRepository;
        _mapper = mapper;
    }

    public async Task<CalendarEventDTO> Create(CalendarEventForCreationDTO calendarEventDTO)
    {
        var calendarEvent = _mapper.Map<CalendarEvent>(calendarEventDTO);
        // var calendar = await _calendarRepository.Retrieve(calendarEventDTO.CalendarId);
        // calendarEvent.Calendar = calendar;
        await _calendarEventRepository.Create(calendarEvent);
        return _mapper.Map<CalendarEventDTO>(calendarEvent);
    }

    public async Task<CalendarEventDTO> Update(Guid idCalendarEvent, CalendarEventForUpdateDTO calendarEventDTO)
    {
        var calendarEvent = await GetRecordAndCheckExistence(idCalendarEvent);
        _mapper.Map(calendarEventDTO, calendarEvent);
        await _calendarEventRepository.Update(calendarEvent);
        return _mapper.Map<CalendarEventDTO>(calendarEvent);
    }

    public async Task Delete(Guid idCalendarEvent)
    {
        var calendarEvent = await GetRecordAndCheckExistence(idCalendarEvent);
        await _calendarEventRepository.Delete(calendarEvent);
    }

    public async Task<CalendarEventDTO?> Retrieve(Guid idCalendarEvent) =>
        _mapper.Map<CalendarEventDTO>(await _calendarEventRepository.Retrieve(idCalendarEvent));

    public async Task<List<CalendarEventDTO>> RetrieveAll() =>
        _mapper.Map<List<CalendarEventDTO>>(await _calendarEventRepository.RetrieveAll());

    private async Task<CalendarEvent> GetRecordAndCheckExistence(Guid idCalendarEvent)
    {
        var calendarEvent = await _calendarEventRepository.Retrieve(idCalendarEvent);
        if (calendarEvent is null)
            throw new EntityNotFoundException("Calendar event not found.");
        return calendarEvent;
    }

    public List<LabelValueDTO<int>> GetEventTypes()
    {
        var list = new List<LabelValueDTO<int>>();
        foreach (var value in Enum.GetValues(typeof(EVENT_TYPES)))
        {
            // Getting the field info for the current enum value
            FieldInfo fi = typeof(EVENT_TYPES).GetField(Enum.GetName(typeof(EVENT_TYPES), value));

            // Getting the DescriptionAttribute, if it exists
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // Setting the label to either the description or the enum name as fallback
            string label = attributes.Length > 0 ? attributes[0].Description : Enum.GetName(typeof(EVENT_TYPES), value);

            list.Add(new LabelValueDTO<int>
            {
                Value = (int)value,
                Label = label
            });
        }
        return list;
    }
}
