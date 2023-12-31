﻿using BaseballStatAndScoreTracker.Common.Models;

namespace BaseballStatAndScoreTracker.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string> AddAccount(NewAccountDto accountDto);
        Task<(string, bool)> Authenticate(LoginCredentialsDto loginCredentials);
    }
}