using BaseballStatAndScoreTracker.Common.Models;
using BaseballStatAndScoreTracker.Domain;
using BaseballStatAndScoreTracker.Repository.Interfaces;
using BaseballStatAndScoreTracker.Services.Extensions;
using BaseballStatAndScoreTracker.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BaseballStatAndScoreTracker.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<string> AddAccount(NewAccountDto accountDto)
        {
            var (account, user, key) = accountDto.CreateNewAccountObjectsFromDto();
            string id = await _accountRepository.AddAccount(account, user, key);
            return id;
        }

        public async Task<(string, bool)> Authenticate(LoginCredentialsDto loginCredentials)
        {
            loginCredentials.ValidateLoginCred();
            var (storedSalt, storedPassword) = await _accountRepository.GetKey(loginCredentials.UserName ?? String.Empty);
            bool isValid = PasswordHashExtention.VerifyPassword(loginCredentials.Password ?? String.Empty, storedPassword, storedSalt);
            if(isValid)
            {
                return (GenerateToken(), isValid);
            }
            return (String.Empty, false);
        }

        private string GenerateToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JimbusChimbus123ABC"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "StatTrakIssuer",        
                audience: "StatTrakAudience",    
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
