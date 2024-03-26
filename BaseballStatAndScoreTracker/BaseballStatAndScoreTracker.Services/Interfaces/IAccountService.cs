using BaseballStatAndScoreTracker.Common.Models;
using BaseballStatAndScoreTracker.Domain;

namespace BaseballStatAndScoreTracker.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string> AddAccount(NewAccountDto accountDto);
        Task<(string, bool)> Authenticate(LoginCredentialsDto loginCredentials);
        Task<AccountDto> GetAccount(string userName);
    }
}