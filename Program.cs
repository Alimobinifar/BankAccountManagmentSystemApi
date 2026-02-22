using BankAccountManagmentSystemApi.Data;
using BankAccountManagmentSystemApi.Services.BankAccountServices;
using BankAccountManagmentSystemApi.Services.MainServices;
using Microsoft.EntityFrameworkCore;
using BankAccountManagmentSystemApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null
        )
    )
);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<AuditService>();
builder.Services.AddScoped<UserSerivce>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
