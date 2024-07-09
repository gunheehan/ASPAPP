using GameStore.Entities;

namespace GameStore.Respositories;

public interface IGamesRepository
{
    Task<IEnumerable<Game>> GetAllAsync();
    Task<Game?> GetAsync(int id);
    Task CreateAsync(Game game);
    Task UpdateAsync(Game updateGame);
    Task DeleteAsync(int id);
}