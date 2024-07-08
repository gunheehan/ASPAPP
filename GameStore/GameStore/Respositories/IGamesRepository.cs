using GameStore.Entities;

namespace GameStore.Respositories;

public interface IGamesRepository
{
    IEnumerable<Game> GetAll();
    Game? Get(int id);
    void Create(Game game);
    void Update(Game updateGame);
    void Delete(int id);
}