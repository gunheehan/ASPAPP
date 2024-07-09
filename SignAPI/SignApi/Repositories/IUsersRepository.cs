namespace SignApi.Repositories;

public interface IUsersRepository
{
    Task<User?> GetUserInfoAsync(string email);
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
}