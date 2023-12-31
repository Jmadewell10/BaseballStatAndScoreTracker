﻿namespace BaseballStatAndScoreTracker.Common.Models
{
    public class NewAccountDto
    {
        public string? AccountId { get; set; }
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public LoginCredentialsDto? Login{ get; set; }
    }
}
