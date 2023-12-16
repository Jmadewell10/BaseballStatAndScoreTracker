using BaseballStatAndScoreTracker.Data;
using BaseballStatAndScoreTracker.Services;
using BaseballStatAndScoreTracker.Services.Interfaces;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureKeyVault;

var builder = WebApplication.CreateBuilder(args);
var keyVaultEndpoint = builder.Configuration["AzureKeyVaultEndpoint"];
if (!string.IsNullOrEmpty(keyVaultEndpoint))
{
    var azureServiceTokenProvider = new AzureServiceTokenProvider();
    var keyVaultClient = new KeyVaultClient(
        new KeyVaultClient.AuthenticationCallback(
            azureServiceTokenProvider.KeyVaultTokenCallback));

    builder.Configuration.AddAzureKeyVault(
        keyVaultEndpoint,
        keyVaultClient,
        new DefaultKeyVaultSecretManager());
}
builder.Services.AddDbContext<StatTrackerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
