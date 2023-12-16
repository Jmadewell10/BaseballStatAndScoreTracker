using BaseballStatAndScoreTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace BaseballStatAndScoreTracker.Data
{
    public class StatTrackerContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Inning> Innings { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }


        public StatTrackerContext(DbContextOptions<StatTrackerContext> options) : base(options)
        {
            
        }

        public StatTrackerContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<Account>(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<Account>(a => a.UserId);

            modelBuilder.Entity<Account>()
                .HasMany<Team>(a => a.Teams)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasMany<Inning>(g => g.Innings)
                .WithOne(i => i.Game)
                .HasForeignKey(i => i.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasMany<Game>(t => t.HomeGames)
                .WithOne(g => g.Home)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasMany<Game>(t => t.AwayGames)
                .WithOne(g => g.Away)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}