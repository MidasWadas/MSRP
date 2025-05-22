using System.ComponentModel.DataAnnotations;

namespace MSRP.API.Requests.Recipe.CreateRecipe;

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
    public CreateRecipeRequest_Difficulty Difficulty { get; init; }

    [Required]
    public CreateRecipeRequest_CuisineType CuisineType { get; init; }

    [Required]
    public CreateRecipeRequest_MealType MealType { get; init; }

    [Required]
    public List<CreateRecipeRequest_DietaryOption> Dietaries { get; init; }

    [Required]
    public List<string> Ingredients { get; init; }

    [Required]
    public List<string> Instructions { get; init; }

    public bool IsFavorite { get; init; }
}

public sealed record CreateRecipeRequest_Difficulty(int Id, string Name);
public sealed record CreateRecipeRequest_MealType(int Id, string Name);
public sealed record CreateRecipeRequest_DietaryOption(int Id, string Name);
public sealed record CreateRecipeRequest_CuisineType(int Id, string Name);