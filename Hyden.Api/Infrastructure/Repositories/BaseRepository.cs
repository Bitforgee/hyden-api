using Hyden.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hyden.Api.Infrastructure.Repositories;

public class BaseRepository<T> where T : class
{
    protected readonly HydenDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(HydenDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }
    public virtual async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<bool> ExistsAsync(object id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity != null;
    }
}
