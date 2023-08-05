using MindXLiveCodeGen8.Domain.Entities;

namespace MindXLiveCodeGen8.Domain.Interfaces.Services;

public interface IAccountService
{
    public Task<List<Account>> GetAll();
}