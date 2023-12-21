using BaseballStatAndScoreTracker.Data;
using BaseballStatAndScoreTracker.Domain;
using BaseballStatAndScoreTracker.Repository.Interfaces;

namespace BaseballStatAndScoreTracker.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StatTrackerContext _context;
        public UserRepository(StatTrackerContext context)
        {
            _context = context;
        }

        public async Task<string> AddUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                _context.SaveChanges();
                return user.UserId.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }
    }
}
