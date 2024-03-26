using BaseballStatAndScoreTracker.Domain;

namespace BaseballStatAndScoreTracker.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<string> AddAccount(Account account, User user, Key key);
        Task<(string, string)> GetKey(string userName);
        Task<IEnumerable<string>> GetAllUserNames();
        Task<Account> GetAccount(string accountId);
        Task<Account> GetAccountByUserName(string userName);
    }
}