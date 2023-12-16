namespace BaseballStatAndScoreTracker.Domain
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public Guid TeamId { get; set; }
        public Team? Team { get; set; }
        public string? Number { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int PlateAppearances { get; set; }
        public int AtBats { get; set; }
        public int Hits { get; set; }
        public int StrikeOuts { get; set; }
        public int Singles { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int HomeRuns { get; set; }
        public int Walks { get; set; }
        public int HitByPitches { get; set; }
        public int RBIs { get; set; }
        public int SacFlys { get; set; }
    }
}
