using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class CalendarService : ICalendarService
{
    private readonly ILoggerService _logger;
    private readonly ICalendarDAL _calendarDAL;
    private readonly IMapper _mapper;

    public CalendarService(
        ILoggerService logger,
        ICalendarDAL calendarDAL,
        IMapper mapper)
    {
        _logger = logger;
        _calendarDAL = calendarDAL;
        _mapper = mapper;
    }

    public async Task<int> Create(CalendarForCreationDTO calendarDTO)
    {
        Calendar calendar = _mapper.Map<Calendar>(calendarDTO);
        return await _calendarDAL.Create(calendar);
    }

    public async Task Update(int id, CalendarForUpdateDTO calendarDTO)
    {
        Calendar calendar = await GetRecordAndCheckExistence(id);
        _mapper.Map(calendarDTO, calendar);
        await _calendarDAL.Update(calendar);
    }

    public async Task Delete(int id)
    {
        Calendar calendar = await GetRecordAndCheckExistence(id);
        await _calendarDAL.Delete(calendar);
    }

    public async Task<CalendarDTO?> Retrieve(int id) => _mapper.Map<CalendarDTO>(await _calendarDAL.Retrieve(id));

    public async Task<List<CalendarDTO>> RetrieveAll() => _mapper.Map<List<CalendarDTO>>(await _calendarDAL.RetrieveAll());

    private async Task<Calendar> GetRecordAndCheckExistence(int id)
    {
        Calendar calendar = await _calendarDAL.Retrieve(id, trackChanges: false);
        if (calendar == null)
            throw new EntityNotFoundException("Calendar not found.");
        return calendar;
    }
}
