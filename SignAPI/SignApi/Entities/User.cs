using System.ComponentModel.DataAnnotations;

namespace SignApi;

public class User
{
    public int Id { get; set; }
    [Required][StringLength(8)]
    public required string Nickname { get; set; }
    [Required][EmailAddress]
    public required string Email { get; set; }
}