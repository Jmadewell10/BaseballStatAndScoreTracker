using BaseballStatAndScoreTracker.Data;
using BaseballStatAndScoreTracker.Repository;
using BaseballStatAndScoreTracker.Repository.Interfaces;
using BaseballStatAndScoreTracker.Services;
using BaseballStatAndScoreTracker.Services.Interfaces;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureKeyVault;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StatTrackerContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnectionString"))
);
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
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
