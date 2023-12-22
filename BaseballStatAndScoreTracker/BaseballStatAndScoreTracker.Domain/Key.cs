namespace BaseballStatAndScoreTracker.Domain
{
    public class Key
    {
        public Guid KeyId { get; set; }
        public Guid UserId { get; set; }
        public string? Salt { get; set; }
        public User? User { get; set; }

    }
}
