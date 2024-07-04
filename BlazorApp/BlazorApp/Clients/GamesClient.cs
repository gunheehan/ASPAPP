using BlazorApp.Models;
namespace BlazorApp.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games =
    [
        new()
        {
            Id = 1,
            Name = "Street Fighter II",
            Genre = "Fighting",
            Price = 19.99M,
            ReleaseDate = new DateOnly(1996, 3, 5)
        },
        new()
        {
            Id = 2,
            Name = "Rinal Fantasy XIV",
            Genre = "Roleplaying",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2010, 3, 15)
        },
        new()
        {
            Id = 3,
            Name = "FIFA 23",
            Genre = "Sports",
            Price = 69.99M,
            ReleaseDate = new DateOnly(2011, 7, 5)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();
    public GameSummary[] GetGames() => games.ToArray();
    
    public void AddGame(GameDetails game)
    {
        var genre = GetGenerById(game.GenreId);

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        
        games.Add(gameSummary);
    }

    private Genre GetGenerById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var genre = genres.Single(genre => genre.Id == int.Parse(id));
        return genre;
    }

    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummartById(id);
        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updateGame)
    {
        var genre = GetGenerById(updateGame.GenreId);
        GameSummary exisingGame = GetGameSummartById(updateGame.Id);

        exisingGame.Name = updateGame.Name;
        exisingGame.Genre = genre.Name;
        exisingGame.Price = updateGame.Price;
        exisingGame.ReleaseDate = updateGame.ReleaseDate;
    }
    
    public void DeleteGame(int id)
    {
        var game = GetGameSummartById(id);
        games.Remove(game);
    }
    
    private GameSummary GetGameSummartById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }
}