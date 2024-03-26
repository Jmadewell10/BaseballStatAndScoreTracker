using BaseballStatAndScoreTracker.Data;
using BaseballStatAndScoreTracker.Domain;
using BaseballStatAndScoreTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStatAndScoreTracker.Repository
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly StatTrackerContext _context;

        public TeamsRepository(StatTrackerContext context)
        {
            _context = context;
        }
        #region public Methods
        public async Task<string> AddNewTeam(Team team)
        {
            try
            {
                await _context.Teams.AddAsync(team);
                return team.TeamId.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }

        #endregion
    }
}
