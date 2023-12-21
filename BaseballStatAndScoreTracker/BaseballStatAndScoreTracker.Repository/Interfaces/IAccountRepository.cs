using BaseballStatAndScoreTracker.Domain;

namespace BaseballStatAndScoreTracker.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<string> AddAccount(Account account);
    }
}