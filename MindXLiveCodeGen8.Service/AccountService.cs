using Microsoft.EntityFrameworkCore;
using MindXLiveCodeGen8.Domain.Entities;
using MindXLiveCodeGen8.Domain.Interfaces;
using MindXLiveCodeGen8.Domain.Interfaces.Services;

namespace MindXLiveCodeGen8.Service;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;

    public AccountService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Account>> GetAll()
    {
        var accounts = await _unitOfWork.Repository<Account>().Entities
            .Include(x => x.Resumes)
            .ToListAsync();
        return accounts;
    }
}