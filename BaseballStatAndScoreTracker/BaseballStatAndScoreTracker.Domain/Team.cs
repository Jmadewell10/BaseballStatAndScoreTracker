namespace BaseballStatAndScoreTracker.Domain
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public Guid AccountId { get; set; }
        public Account? Account { get; set; }
        public string? TeamName { get; set; }
        public List<Player>? Players { get; set; }
        public List<Game>? HomeGames { get; set; }
        public List<Game>? AwayGames { get; set; }
    }
}
