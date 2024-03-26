using BaseballStatAndScoreTracker.Common.Models;
using BaseballStatAndScoreTracker.Domain;
using BaseballStatAndScoreTracker.Repository;
using BaseballStatAndScoreTracker.Repository.Interfaces;
using BaseballStatAndScoreTracker.Services.Interfaces;
using Microsoft.Extensions.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStatAndScoreTracker.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamsRepository _teamsRepo;
        private readonly IAccountRepository _accountRepo;

        public TeamService(ITeamsRepository teamsRepo, IAccountRepository accountRepo)
        {
            _teamsRepo = teamsRepo;
            _accountRepo = accountRepo;
        }

        public async Task<string> AddTeam(NewTeamDto teamDto)
        {
            Team team = await CreateNewTeamObject(teamDto.TeamName ?? String.Empty, teamDto.AccountId ?? String.Empty);
            var teamId = await _teamsRepo.AddNewTeam(team);
            return teamId;
        }

        private async Task<Team> CreateNewTeamObject(string teamName, string accountId)
        {
            var account = await _accountRepo.GetAccount(accountId);
            return new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = teamName,
                AccountId = Guid.Parse(accountId),
                Account = account
            };

        }
    }
}
