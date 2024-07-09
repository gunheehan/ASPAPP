using GameStore.Dto.Data;
using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Respositories;

public class EntityFrameWorkGamesRepository : IGamesRepository
{
    private readonly GameStoreContext dbContext;

    public EntityFrameWorkGamesRepository(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await dbContext.Games.AsNoTracking().ToListAsync();
    }

    public async Task<Game?> GetAsync(int id)
    {
        return await dbContext.Games.FindAsync(id);
    }

    public async Task CreateAsync(Game game)
    {
        dbContext.Games.Add(game);
        dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Game updateGame)
    {
        dbContext.Update(updateGame);
        dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        dbContext.Games.Where(game => game.Id == id)
            .ExecuteDeleteAsync();
    }
}