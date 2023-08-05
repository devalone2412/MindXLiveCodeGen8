using Microsoft.EntityFrameworkCore;

namespace MindXLiveCodeGen8.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    DbContext? DbContext { get; }
    IRepository<T> Repository<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}