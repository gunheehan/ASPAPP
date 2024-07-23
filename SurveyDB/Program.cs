using SurveyDB.Data;
using SurveyDB.Models;
using SurveyDB.Repositories;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SurveyDbContext>();
builder.Services.AddRespositories(builder.Configuration);
builder.Services.AddScoped<ISurveyRepository, SurveyRepository>();

var app = builder.Build();

//app.Services.InitializeDb();

app.Run();