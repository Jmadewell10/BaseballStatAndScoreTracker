using BaseballStatAndScoreTracker.Data;
using BaseballStatAndScoreTracker.Domain;
using BaseballStatAndScoreTracker.Repository.Interfaces;

namespace BaseballStatAndScoreTracker.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly StatTrackerContext _context;

        public AccountRepository(StatTrackerContext context)
        {
            _context = context;
        }

        public async Task<string> AddAccount(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                return account.AccountId.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }
    }
}