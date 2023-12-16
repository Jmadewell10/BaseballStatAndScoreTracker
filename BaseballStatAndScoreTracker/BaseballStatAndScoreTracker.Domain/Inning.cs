namespace BaseballStatAndScoreTracker.Domain
{
    public class Inning
    {
        public Guid InningId { get; set; }
        public Guid GameId { get; set; }
        public Game? Game { get; set; }
        public int Runs { get; set; }
        public int Hits { get; set; }
        public int Errors { get; set; }

    }
}
