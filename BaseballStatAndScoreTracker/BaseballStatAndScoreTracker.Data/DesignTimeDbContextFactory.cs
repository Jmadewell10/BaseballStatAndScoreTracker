using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace BaseballStatAndScoreTracker.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StatTrackerContext>
    {
        public StatTrackerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StatTrackerContext>();
            optionsBuilder.UseSqlServer("",
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });
            return new StatTrackerContext(optionsBuilder.Options);
        }
    }

}
