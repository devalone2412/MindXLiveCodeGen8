using Microsoft.EntityFrameworkCore;

namespace MindXLiveCodeGen8.Domain.Interfaces;

public interface IRepository<T> where T: class
{
    DbSet<T> Entities { get; }
    DbContext DbContext { get; }

    Task<List<T>> GetAllAsync();
    T? Find(params object[] keyValues);
    ValueTask<T?> FindAsync(params object[] keyValues);
    Task InsertAsync(T entity, bool saveChanges = true);
    Task UpdateAsync(T entity, bool saveChanges = true);
    Task InsertRangeAsync(IEnumerable<T> entities, bool saveChanges = true);
    Task DeleteAsync(Guid id, bool saveChanges = true);
    Task DeleteAsync(T entity, bool saveChanges = true);
    Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true);
}