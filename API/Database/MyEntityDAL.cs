using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class MyEntityDAL : RepositoryBase<MyEntity>, IMyEntityDAL
{
    private readonly ApplicationDbContext _context;

    public MyEntityDAL(ApplicationDbContext context) : base(context)
    {
        _context = context; 
    }

    public async Task<int> Create(MyEntity myEntity)
    {
        await base.Create(myEntity);
        return myEntity.Id; // Assuming Id is auto-generated
    }

    public async Task Update(MyEntity myEntity) => await base.Update(myEntity);

    public async Task Delete(MyEntity myEntity) => await base.Delete(myEntity);

    public async Task<MyEntity?> Retrieve(int idMyEntity, bool trackChanges = false) =>
        await FindByCondition(p => p.Id == idMyEntity, trackChanges)
                .FirstOrDefaultAsync(m => m.Id == idMyEntity);

    public async Task<List<MyEntity>> RetrieveAll() => await FindAll().ToListAsync();
}