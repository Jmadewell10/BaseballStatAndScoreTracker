using BaseballStatAndScoreTracker.Common.Models;
using BaseballStatAndScoreTracker.Domain;
using BaseballStatAndScoreTracker.Repository.Interfaces;
using BaseballStatAndScoreTracker.Services.Extensions;
using BaseballStatAndScoreTracker.Services.Interfaces;

namespace BaseballStatAndScoreTracker.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public AccountService(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public async Task<string> AddAccount(NewAccountDto accountDto)
        {
            Account account = accountDto.TransformNewAccountToAccount();
            accountDto.AccountId = account.AccountId.ToString();
            User user = accountDto.GetUserFromAccountDto();
            account.UserId = user.UserId;
            user.AccountId = account.AccountId;
            await _userRepository.AddUser(user);
            string id = await _accountRepository.AddAccount(account);
            return id;
        }
    }
}
