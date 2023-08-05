using MindXLiveCodeGen8.Domain.Entities;
using MindXLiveCodeGen8.Domain.Interfaces;
using MindXLiveCodeGen8.Domain.Interfaces.Services;

namespace MindXLiveCodeGen8.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> SignUp(string userName, string password)
    {
        var existUserInDb = _unitOfWork.Repository<Account>().Entities.Any(x => x.UserName == userName);
        if (!existUserInDb)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var newAccount = new Account
                {
                    UserName = userName,
                    Password = password
                };

                await _unitOfWork.Repository<Account>().InsertAsync(newAccount);
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        return false;
    }

    public async Task<string> Login(string userName, string password)
    {
        var account = _unitOfWork.Repository<Account>().Entities
            .FirstOrDefault(x => x.UserName == userName && x.Password == password);

        if (account is null) 
            return string.Empty;
        
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            account.Token = Guid.NewGuid().ToString();

            await _unitOfWork.Repository<Account>().UpdateAsync(account);
            await _unitOfWork.CommitTransactionAsync();

            return account.Token;
        }
        catch (Exception e)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}