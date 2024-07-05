using BlazorApp.Models;
namespace BlazorApp.Clients;

public class GamesClient(HttpClient httpClient)
{
    public async Task<GameSummary[]> GetGamesAsync()
        => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

    public async Task AddGameAsync(GameDetails game)
        => await httpClient.PostAsJsonAsync("games", game);

    public async Task<GameDetails> GetGameAsync(int id)
        => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}")
           ?? throw new Exception("Could Not Find Game!");

    public async Task UpdateGameAsync(GameDetails updateGame)
        => await httpClient.PutAsJsonAsync($"games/{updateGame.Id}", updateGame);

    public async Task DeleteGameAsync(int id)
        => await httpClient.DeleteAsync($"games/{id}");
}