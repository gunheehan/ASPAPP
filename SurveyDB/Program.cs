using Azure.ResourceManager.MySql.Models;
using SurveyDB.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("AppDbContext"), new Version(9,0,0)));


var app = builder.Build();

app.Services.InitializeDb();

app.Run();
