namespace BaseballStatAndScoreTracker.Domain
{
    public class Key
    {
        public Guid KeyId { get; set; }
        public Guid UserId { get; set; }
        public string? Hash { get; set; }
        public User? User { get; set; }

    }
}
