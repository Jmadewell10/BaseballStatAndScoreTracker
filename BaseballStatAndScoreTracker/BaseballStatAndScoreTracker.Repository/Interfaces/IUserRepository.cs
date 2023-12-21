using BaseballStatAndScoreTracker.Domain;

namespace BaseballStatAndScoreTracker.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<string> AddUser(User user);
    }
}