using System.ComponentModel.DataAnnotations;

namespace SignApi;

public class Dtos
{
    public record UserDto(
        int Id,
        string Nickname,
        string Email
    );

    public record CreateUserDto(
        string Id,
        [Required][StringLength(8)] string Nickname,
        [Required][EmailAddress] string Email
    );

    public record UpdateUserDto(
        string Id,
        [Required][StringLength(8)] string Nickname,
        [Required][EmailAddress] string Email
    );
}