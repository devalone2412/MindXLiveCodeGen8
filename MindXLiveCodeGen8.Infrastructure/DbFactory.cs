using Microsoft.EntityFrameworkCore;

namespace MindXLiveCodeGen8.Infrastructure;

public class DbFactory : IDisposable
{
    private bool _disposed;
    private readonly Func<OnlineResumeDbContext> _instanceFunc;
    private OnlineResumeDbContext _onlineResumeDbContext;
    public OnlineResumeDbContext OnlineResumeDbContext => _onlineResumeDbContext ??= _instanceFunc.Invoke();

    public DbFactory(Func<OnlineResumeDbContext> dbContextFactory)
    {
        _instanceFunc = dbContextFactory;
    }

    public void Dispose()
    {
        if (_disposed || _onlineResumeDbContext == null)
            return;

        _disposed = true;
        _onlineResumeDbContext.Dispose();
    }
}