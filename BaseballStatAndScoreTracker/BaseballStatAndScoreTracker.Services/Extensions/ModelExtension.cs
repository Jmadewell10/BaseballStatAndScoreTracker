using BaseballStatAndScoreTracker.Common.Models;
using BaseballStatAndScoreTracker.Domain;

namespace BaseballStatAndScoreTracker.Services.Extensions
{
    public static class ModelExtension
    {
        public static Account TransformNewAccountToAccount(this NewAccountDto accountDto)
        {
            Account account = new Account() { 
                AccountId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                FirstName = accountDto.FirstName,
                LastName = accountDto.LastName,
                Email = accountDto.Email
            };
            return account;
        }

        public static User GetUserFromAccountDto(this NewAccountDto account) 
        {
            ArgumentNullException.ThrowIfNull(account.AccountId);
            User user = new User()
            {
                UserId = Guid.NewGuid(),
                UserName = account.UserName,
                AccountId = Guid.Parse(account.AccountId),
                Password = account.Password
            };
            return user;
        }
    }
}
