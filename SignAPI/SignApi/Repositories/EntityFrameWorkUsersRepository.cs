using SignApi.Data;

namespace SignApi.Repositories;

public class EntityFrameWorkUsersRepository : IUsersRepository
{
    private readonly UserContext dbContext;

    public EntityFrameWorkUsersRepository(UserContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<User?> GetUserInfoAsync(string email)
    {
        return await dbContext.Users.FindAsync(email);
    }

    public async Task CreateUserAsync(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        dbContext.Users.Update(user);
        await dbContext.SaveChangesAsync();
    }
}