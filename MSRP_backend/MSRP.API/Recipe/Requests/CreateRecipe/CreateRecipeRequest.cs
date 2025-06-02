using System.ComponentModel.DataAnnotations;

namespace MSRP.API.Recipe.Requests.CreateRecipe;

public sealed class CreateRecipeRequest
{
    [Required]
    public string Title { get; init; }

    [Required]
    public string Description { get; init; }

    [Required]
    [Url]
    public string ImageUrl { get; init; }

    [Required]
    [Range(1, int.MaxValue)]
    public int PrepTime { get; init; }

    [Required]
    [Range(1, int.MaxValue)]
    public int CookTime { get; init; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Servings { get; init; }

    [Required]
    public int DifficultyId { get; init; }

    [Required]
    public int CuisineId { get; init; }

    [Required]
    public int MealTypeId { get; init; }

    [Required]
    public List<int> DietariesIds { get; init; }

    [Required]
    public List<string> Ingredients { get; init; }

    [Required]
    public List<string> Instructions { get; init; }

    public int CreaterByUserId { get; init; }
}