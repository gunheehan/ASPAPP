using SignApi.Repositories;

namespace SignApi.SignEndPoint;

public static class SignEndPoint
{
    public static RouteGroupBuilder MapSignEndPoint(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/Users");

        group.MapGet("/", async (IUsersRepository repository, User user) =>
        {
            User? newuser = await repository.GetUserInfoAsync(user.Email);

            if (newuser is null)
                await repository.CreateUserAsync(user);

            return Results.Ok(newuser);
        });

        group.MapPost("/", async (IUsersRepository repository, User user) =>
        {
            await repository.CreateUserAsync(user);

            return Results.Ok(user);
        });

        group.MapPut("/", async (IUsersRepository repository, User user) =>
        {
            await repository.UpdateUserAsync(user);

            return Results.Ok(user);
        });
        
    return group;
    }

    //DataBase Add 
    private static User UserAddUserInfo(User user)
    {
        return user;
    }
}