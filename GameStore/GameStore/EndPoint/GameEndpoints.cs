using GameStore.Dto;
using GameStore.Entities;
using GameStore.Respositories;

namespace GameStore.EndPoint;

public static class GameEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games")
            .WithParameterValidation();

        group.MapGet("/", (IGamesRepository repository) => 
            repository.GetAll().Select(game => game.AsDto()));

        group.MapGet("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? game = repository.Get(id);
            
            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
        }).WithName(GetGameEndpointName);

        group.MapPost("", (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri
            };
            
            repository.Create(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
        });

        group.MapPut("/{id}", (IGamesRepository repository, int id, UpdateGameDto updateGameDto) =>
        {
            Game? existingGame = repository.Get(id);

            if (existingGame is null)
                return Results.NotFound();

            existingGame.Name = updateGameDto.Name;
            existingGame.Genre = updateGameDto.Genre;
            existingGame.Price = updateGameDto.Price;
            existingGame.ReleaseDate = updateGameDto.ReleaseDate;
            existingGame.ImageUri = updateGameDto.ImageUri;
            
            repository.Update(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? game = repository.Get(id);

            if (game is not null)
            {
                repository.Delete(game.Id);
                return Results.Ok("Game Delete Success");
            }

            return Results.NoContent();
        });

        return group;
        
        
    }
}