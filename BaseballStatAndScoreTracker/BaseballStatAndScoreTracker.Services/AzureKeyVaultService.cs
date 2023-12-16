using BaseballStatAndScoreTracker.Common.Constants;
using BaseballStatAndScoreTracker.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BaseballStatAndScoreTracker.Services
{
    public class AzureKeyVaultService : IAzureKeyVaultService
    {
        private readonly IConfiguration _configuration;
        public AzureKeyVaultService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetSecretFromKeyVault()
        {
            string secret = _configuration[Constants.SQL_CONNECTION_STRING];
            return secret;
        }
    }
}
