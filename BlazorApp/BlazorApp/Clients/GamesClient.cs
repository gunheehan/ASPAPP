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
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));
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
}