using GameStore.Dto.Data;
using GameStore.EndPoint;
using GameStore.Respositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IGamesRepository, InMemGamesRepository>();

var connString = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();