namespace MindXLiveCodeGen8.Domain.Interfaces.Services;

public interface IAuthenticationService
{
    Task<bool> SignUp(string userName, string password);
    Task<string> Login(string userName, string password);
}