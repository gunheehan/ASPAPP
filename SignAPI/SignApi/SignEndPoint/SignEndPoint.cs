using SignApi.Repositories;

namespace SignApi.SignEndPoint;

public static class SignEndPoint
{
    public static RouteGroupBuilder MapSignEndPoint(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/Users");

        group.MapGet("/", async (IUsersRepository repository, Dtos.UserDto user) =>
        {
            User? newuser = await repository.GetUserInfoAsync(user.Email);

            if (newuser is null)
            {
                User addUser = new User()
                {
                    Nickname = user.Nickname,
                    Email = user.Email
                };
                await repository.CreateUserAsync(addUser);
            }

            return Results.Ok(newuser);
        });

        group.MapPost("/", async (IUsersRepository repository, Dtos.UserDto user) =>
        {
            User newuser = new User()
            {
                Nickname = user.Nickname,
                Email = user.Email
            };
            
            await repository.CreateUserAsync(newuser);

            return Results.Ok(newuser);
        });

        group.MapPut("/", async (IUsersRepository repository, Dtos.UserDto user) =>
        {
            User newuser = new User()
            {
                Nickname = user.Nickname,
                Email = user.Email
            };
            
            await repository.UpdateUserAsync(newuser);

            return Results.Ok(newuser);
        });
        
    return group;
    }

    //DataBase Add 
    private static User UserAddUserInfo(User user)
    {
        return user;
    }
}