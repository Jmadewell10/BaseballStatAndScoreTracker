using BaseballStatAndScoreTracker.Common.Models;
using BaseballStatAndScoreTracker.Domain;

namespace BaseballStatAndScoreTracker.Services.Extensions
{
    public static class ModelExtension
    {
        public static (Account, User, Key) CreateNewAccountObjectsFromDto(this NewAccountDto accountDto)
        {
            ArgumentNullException.ThrowIfNull(accountDto.AccountId);
            ArgumentNullException.ThrowIfNull(accountDto.Login);
            ArgumentNullException.ThrowIfNull(accountDto.Login.Password);
            ArgumentNullException.ThrowIfNull(accountDto.Login.UserName);

            var (hash, salt) = PasswordHashExtention.HashPassword(accountDto.Login.Password);

            Account account = new Account() { 
                AccountId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                FirstName = accountDto.FirstName,
                LastName = accountDto.LastName,
                Email = accountDto.Email
            };

            User user = new User()
            {
                UserId = account.UserId,
                UserName = accountDto.Login.UserName,
                AccountId = account.AccountId,
                Password = hash
            };

            Key key = new Key()
            {
                KeyId = Guid.NewGuid(),
                UserId = user.UserId,
                Salt = salt
            };

            account.UserId = user.UserId;
            user.AccountId = account.AccountId;
            user.Account = account;
            user.KeyId = key.KeyId;

            return (account, user, key);
        }
    }
}
