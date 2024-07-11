using SignApi.Data;
using SignApi.SignEndPoint;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

app.Services.InitalizeDbAsync();

app.MapSignEndPoint(); 
app.Run();
