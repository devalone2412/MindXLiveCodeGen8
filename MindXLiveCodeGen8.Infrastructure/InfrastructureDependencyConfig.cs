using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindXLiveCodeGen8.Domain.Interfaces;

namespace MindXLiveCodeGen8.Infrastructure;

public static class InfrastructureDependencyConfig
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var databasePath = Path.Join(path, configuration["DbName"]);
        
        serviceCollection.AddDbContext<OnlineResumeDbContext>(options =>
        {
            options.UseSqlite($"Data Source={databasePath}");
        });
        
        serviceCollection.AddScoped<Func<OnlineResumeDbContext>>((provider) => () => provider.GetService<OnlineResumeDbContext>());
        serviceCollection.AddScoped<DbFactory>();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
 
        return serviceCollection;
    }
}