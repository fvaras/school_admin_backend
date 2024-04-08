using school_admin_api.Model;

namespace school_admin_api.Contracts.Database;

public interface ICalendarDAL
{
    Task<int> Create(Calendar calendar);
    Task Update(Calendar calendar);
    Task Delete(Calendar calendar);
    Task<Calendar?> Retrieve(int id, bool trackChanges = false);
    Task<List<Calendar>> RetrieveAll();
}