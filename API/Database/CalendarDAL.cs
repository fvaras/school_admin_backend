using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class CalendarDAL : RepositoryBase<Calendar>, ICalendarDAL
{
    private readonly ApplicationDbContext _context;

    public CalendarDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Calendar calendar)
    {
        await base.Create(calendar);
        return calendar.Id; // Assuming Id is auto-generated
    }

    public async Task Update(Calendar calendar) => await base.Update(calendar);

    public async Task Delete(Calendar calendar) => await base.Delete(calendar);

    public async Task<Calendar?> Retrieve(Guid id, bool trackChanges = false) =>
        await FindByCondition(c => c.Id == id, trackChanges).SingleOrDefaultAsync();

    public async Task<List<Calendar>> RetrieveAll() => await FindAll().ToListAsync();
}