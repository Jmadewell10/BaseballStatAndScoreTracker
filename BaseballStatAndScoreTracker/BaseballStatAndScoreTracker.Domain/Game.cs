namespace BaseballStatAndScoreTracker.Domain
{
    public class Game
    {
        public Guid GameId { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public Team? Home { get; set; }
        public Team? Away { get; set; }
        public int  HomeScore { get; set; }
        public int AwayScore { get; set; }
        public List<Inning>? Innings { get; set; }
    }
}
