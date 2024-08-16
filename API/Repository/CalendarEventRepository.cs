using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Repository;
using school_admin_api.Model;

namespace school_admin_api.Repository;

public class CalendarEventRepository : RepositoryBase<CalendarEvent>, ICalendarEventRepository
{
    private readonly ApplicationDbContext _context;

    public CalendarEventRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Guid> Create(CalendarEvent calendarEvent)
    {
        await base.Create(calendarEvent);
        return calendarEvent.Id;
    }

    public async Task Update(CalendarEvent calendarEvent) => await base.Update(calendarEvent);

    public async Task Delete(CalendarEvent calendarEvent) => await base.Delete(calendarEvent);

    public async Task<CalendarEvent?> Retrieve(Guid idCalendarEvent, bool trackChanges = false) =>
        await FindByCondition(e => e.Id == idCalendarEvent, trackChanges).SingleOrDefaultAsync();

    public async Task<List<CalendarEvent>> RetrieveAll() => await FindAll().ToListAsync();
}
