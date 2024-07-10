namespace SignApi;

public static class EntityExtensions
{
    public static Dtos.UserDto AsDto(this User user)
    {
        return new Dtos.UserDto(
        user.Id,
        user.Nickname,
        user.Email
        );
    }
}