using BaseballStatAndScoreTracker.Common.Models;

namespace BaseballStatAndScoreTracker.Services.Interfaces
{
    public interface ITeamService
    {
        Task<string> AddTeam(NewTeamDto teamDto);
    }
}