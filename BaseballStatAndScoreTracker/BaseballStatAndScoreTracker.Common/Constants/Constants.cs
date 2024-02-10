namespace BaseballStatAndScoreTracker.Common.Constants
{
    public class Constants
    {
        public const string SQL_CONNECTION_STRING = "SQLServerConnectionString";
        public const string ISSUER = "StatTrakIssuer";
        public const string AUDIENCE = "StatTrakAudience";
        public const string SECRET = "JimbusChimbus123ABC";
    }

    public class ErrorConstants 
    {
        public const string INVALID_CREDENTIALS = "Login credentials provided do not meet minimum requirements";
        public const string INCORRECT_CREDENTIALS = "Login credentials provided are incorrect";
    }

}