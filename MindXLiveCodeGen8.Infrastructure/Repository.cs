using Microsoft.EntityFrameworkCore;
using MindXLiveCodeGen8.Domain.Interfaces;

namespace MindXLiveCodeGen8.Infrastructure;

public class Repository<T> : IRepository<T> where T : class
{
    public Repository(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    public DbSet<T> Entities => DbContext.Set<T>();
    public DbContext DbContext { get; }
    public async Task<List<T>> GetAllAsync()
    {
        return await Entities.ToListAsync();
    }

    public T? Find(params object[] keyValues)
    {
        return Entities.Find(keyValues);
    }

    public async ValueTask<T?> FindAsync(params object[] keyValues)
    {
        return await Entities.FindAsync(keyValues);
    }

    public async Task InsertAsync(T entity, bool saveChanges = true)
    {
        await Entities.AddAsync(entity);

        if (saveChanges)
        {
            await DbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(T entity, bool saveChanges = true)
    {
        Entities.Update(entity);

        if (saveChanges)
        {
            await DbContext.SaveChangesAsync();
        }
    }

    public async Task InsertRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
    {
        await Entities.AddRangeAsync(entities);

        if (saveChanges)
        {
            await DbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid id, bool saveChanges = true)
    {
        var entity = await Entities.FindAsync(id);

        if (entity is null)
        {
            return;
        }
        
        await DeleteAsync(entity);

        if (saveChanges)
        {
            await DbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(T entity, bool saveChanges = true)
    {
        Entities.Remove(entity);

        if (saveChanges)
        {
            await DbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
    {
        var enumerable = entities as T[] ?? entities.ToArray();
        if (enumerable.Any())
        {
            Entities.RemoveRange(enumerable);
        }

        if (saveChanges)
        {
            await DbContext.SaveChangesAsync();
        }
    }
}