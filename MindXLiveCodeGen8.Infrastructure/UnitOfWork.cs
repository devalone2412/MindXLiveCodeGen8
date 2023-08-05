using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MindXLiveCodeGen8.Domain.Interfaces;

namespace MindXLiveCodeGen8.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public DbContext DbContext { get; private set; }
    private Dictionary<string, object> Repositories { get; }
    private IDbContextTransaction _transaction;
    private IsolationLevel? _isolationLevel;

    public UnitOfWork(DbFactory dbFactory)
    {
        DbContext = dbFactory.OnlineResumeDbContext;
        Repositories = new Dictionary<string, dynamic>();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task StartNewTransactionIfNeeded()
    {
        if (_transaction == null)
        {
            _transaction = _isolationLevel.HasValue
                ? await DbContext.Database.BeginTransactionAsync(_isolationLevel.GetValueOrDefault())
                : await DbContext.Database.BeginTransactionAsync();
        }
    }

    public async Task BeginTransactionAsync()
    {
        await StartNewTransactionIfNeeded();
    }

    public async Task CommitTransactionAsync()
    {
        /*
        do not open transaction here, because if during the request
        nothing was changed(only select queries were run), we don't
        want to open and commit an empty transaction -calling SaveChanges()
        on _transactionProvider will not send any sql to database in such case
        */
        await DbContext.SaveChangesAsync();

        if (_transaction == null) return;
        await _transaction.CommitAsync();

        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction == null) return;

        await _transaction.RollbackAsync();

        await _transaction.DisposeAsync();
        _transaction = null;
    }


    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity);
        var typeName = type.Name;

        lock (Repositories)
        {
            if (Repositories.TryGetValue(typeName, out var repository1))
            {
                return (IRepository<TEntity>)repository1;
            }

            var repository = new Repository<TEntity>(DbContext);

            Repositories.Add(typeName, repository);
            return repository;
        }
    }

    public void Dispose()
    {
        if (DbContext.Database.GetDbConnection().State == ConnectionState.Open)
        {
            DbContext.Database.GetDbConnection().Close();
        }

        DbContext.Dispose();
        DbContext = null;
    }
}