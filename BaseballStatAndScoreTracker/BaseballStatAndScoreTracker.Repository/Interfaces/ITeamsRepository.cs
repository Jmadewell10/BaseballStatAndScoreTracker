using BaseballStatAndScoreTracker.Domain;

namespace BaseballStatAndScoreTracker.Repository.Interfaces
{
    public interface ITeamsRepository
    {
        Task<string> AddNewTeam(Team team);
    }
}