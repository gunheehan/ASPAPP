
using SignApi;

List<User> users = new()
{
    new User()
    {
        Nickname = "gungun",
        Email = "han.gh@salin.co.kr"
    }
};


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/Users", () => users);

app.Run();
