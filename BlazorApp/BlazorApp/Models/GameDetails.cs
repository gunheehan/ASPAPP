using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BlazorApp.Converters;

namespace BlazorApp.Models;

public class GameDetails
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    [Required(ErrorMessage = "The Genre filed is required")]
    [JsonConverter(typeof(StringConverter))]
    public string? GenreId { get; set; }
     public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}