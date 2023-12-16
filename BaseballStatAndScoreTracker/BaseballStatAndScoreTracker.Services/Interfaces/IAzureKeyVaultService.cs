namespace BaseballStatAndScoreTracker.Services.Interfaces
{
    public interface IAzureKeyVaultService
    {
        string GetSecretFromKeyVault();
    }
}