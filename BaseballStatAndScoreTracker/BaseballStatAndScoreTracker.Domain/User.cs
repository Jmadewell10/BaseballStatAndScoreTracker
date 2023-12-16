namespace BaseballStatAndScoreTracker.Domain
{
    public class User
    {
        public Guid UserId { get; set; }
        public Guid AccountId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public Account? Account { get; set; }

    }
}