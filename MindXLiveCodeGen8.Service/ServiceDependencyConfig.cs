using Microsoft.Extensions.DependencyInjection;
using MindXLiveCodeGen8.Domain.Interfaces.Services;

namespace MindXLiveCodeGen8.Service;

public static class ServiceDependencyConfig
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IAccountService, AccountService>();
        serviceCollection.AddTransient<IAuthenticationService, AuthenticationService>();
        return serviceCollection;
    }
}