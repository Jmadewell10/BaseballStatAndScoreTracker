using BaseballStatAndScoreTracker.Data;
using BaseballStatAndScoreTracker.Domain;
using BaseballStatAndScoreTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Key = BaseballStatAndScoreTracker.Domain.Key;

namespace BaseballStatAndScoreTracker.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly StatTrackerContext _context;

        public AccountRepository(StatTrackerContext context)
        {
            _context = context;
        }

        public async Task<string> AddAccount(Account account, User user, Key key)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.Key.AddAsync(key);
                await _context.Accounts.AddAsync(account);
                await _context.SaveChangesAsync();
                return account.AccountId.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }

        public async Task<(string, string)> GetKey(string userName)
        {
            try
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName) ?? new User();
                Key key = await _context.Key.FirstOrDefaultAsync(k => k.UserId == user.UserId) ?? new Key();
                ArgumentNullException.ThrowIfNull(key.Salt);
                ArgumentNullException.ThrowIfNull(user.Password);
                return (key.Salt, user.Password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetAllUserNames()
        {
            try
            {
                IEnumerable<string> userNames = await _context.Users.Select(u => u.UserName ?? "").ToListAsync();
                return userNames;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }
    }
}