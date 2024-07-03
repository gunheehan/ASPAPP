using BlazorApp.Models;

namespace BlazorApp.Clients;

public class GenresClient
{
    private readonly Genre[] genres =
    [
        new()
        {
            Id = 1,
            Name = "Fighting"
        },
        new()
        {
            Id = 2,
            Name = "Roleplaying"
        },
        new()
        {
            Id = 3,
            Name = "Sports"
        },
        new()
        {
            Id = 4,
            Name = "Racing"
        },
        new()
        {
            Id = 5,
            Name = "kids and Famliy"
        }
    ];

    public Genre[] GetGenres() => genres;
}