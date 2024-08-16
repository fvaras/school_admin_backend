using AutoMapper;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Repository;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class CalendarService : ICalendarService
{
    private readonly ILoggerService _logger;
    private readonly ICalendarRepository _calendarRepository;
    private readonly IMapper _mapper;

    public CalendarService(
        ILoggerService logger,
        ICalendarRepository calendarRepository,
        IMapper mapper)
    {
        _logger = logger;
        _calendarRepository = calendarRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Create(CalendarForCreationDTO calendarDTO)
    {
        Calendar calendar = _mapper.Map<Calendar>(calendarDTO);
        return await _calendarRepository.Create(calendar);
    }

    public async Task Update(Guid id, CalendarForUpdateDTO calendarDTO)
    {
        Calendar calendar = await GetRecordAndCheckExistence(id);
        _mapper.Map(calendarDTO, calendar);
        await _calendarRepository.Update(calendar);
    }

    public async Task Delete(Guid id)
    {
        Calendar calendar = await GetRecordAndCheckExistence(id);
        await _calendarRepository.Delete(calendar);
    }

    public async Task<CalendarDTO?> Retrieve(Guid id) => _mapper.Map<CalendarDTO>(await _calendarRepository.Retrieve(id));

    public async Task<List<CalendarDTO>> RetrieveAll() => _mapper.Map<List<CalendarDTO>>(await _calendarRepository.RetrieveAll());

    private async Task<Calendar> GetRecordAndCheckExistence(Guid id)
    {
        Calendar calendar = await _calendarRepository.Retrieve(id, trackChanges: false);
        if (calendar == null)
            throw new EntityNotFoundException("Calendar not found.");
        return calendar;
    }
}
