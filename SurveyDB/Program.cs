using Microsoft.EntityFrameworkCore;
using SurveyDB.Data;


var dbHost = "localhost";
var dbName = "loginDB-mysql-container";
var dbPawword = "salin2017";
var connectionString = $"Data source={dbHost}; Initial Catalog={dbName};User ID=root;Password={dbPawword}";


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<AppDbContext>();

try
{
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    Console.WriteLine("MigrationError : ");
    Console.WriteLine(ex);
}


app.Run();
