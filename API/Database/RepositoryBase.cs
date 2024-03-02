using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace school_admin_api.Database;

public abstract class RepositoryBase<T> where T : class
{
    protected ApplicationDbContext _context;

    public RepositoryBase(ApplicationDbContext context) => _context = context;

    public async Task Create(T entity, bool saveChanges = true)
    {
        _context.Set<T>().Add(entity);
        if (saveChanges)
            await _context.SaveChangesAsync();
    }

    public async Task Update(T entity, bool saveChanges = true)
    {
        _context.Set<T>().Update(entity);
        if (saveChanges)
            await _context.SaveChangesAsync();
    }

    public async Task Delete(T myEntity, bool saveChanges = true)
    {
        _context.Set<T>().Remove(myEntity);
        if (saveChanges)
            await _context.SaveChangesAsync();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges ?
            _context.Set<T>()
                .Where(expression)
                .AsNoTracking()
            : _context.Set<T>()
                .Where(expression);

    public IQueryable<T> FindAll(bool trackChanges = false) =>
        !trackChanges ?
            _context.Set<T>().AsNoTracking()
            : _context.Set<T>();
}
