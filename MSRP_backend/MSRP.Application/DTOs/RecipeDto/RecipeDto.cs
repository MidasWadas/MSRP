using MSRP.Domain.Entities.Recipe;

namespace MSRP.Application.DTOs.RecipeDto
{
    public class RecipeDto(
        int id,
        string title,
        string description,
        string imageUrl,
        int prepTime,
        int cookTime,
        int servings,
        DifficultyDto difficulty,
        CuisineTypeDto cuisineType,
        MealTypeDto mealType,
        List<DietaryOptionDto> dietaries,
        List<string> ingredients,
        List<string> instructions,
        bool isFavourite
        )
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
        public string ImageUrl { get; set; } = imageUrl;
        public int PrepTime { get; set; } = prepTime;
        public int CookTime { get; set; } = cookTime;
        public int Servings { get; set; } = servings;
        public DifficultyDto Difficulty { get; set; } = difficulty;
        public CuisineTypeDto CuisineType { get; set; } = cuisineType;
        public MealTypeDto MealType { get; set; } = mealType;
        public List<DietaryOptionDto> Dietaries { get; set; } = dietaries;
        public List<string> Ingredients { get; set; } = ingredients;
        public List<string> Instructions { get; set; } = instructions;
        public bool IsFavorite { get; set; } = isFavourite;

        public static RecipeDto FromRecipe(Recipe recipe) =>
            new(
                recipe.Id,
                recipe.Title,
                recipe.Description,
                recipe.ImageUrl,
                recipe.PrepTime,
                recipe.CookTime,
                recipe.Servings,
                new DifficultyDto(recipe.Difficulty.Id, recipe.Difficulty.Name),
                new CuisineTypeDto(recipe.CuisineType.Id, recipe.CuisineType.Name),
                new MealTypeDto(recipe.MealType.Id, recipe.MealType.Name),
                recipe.Dietaries.Select(d => new DietaryOptionDto(d.Id, d.Name)).ToList(),
                recipe.Ingredients.ToList(),
                recipe.Instructions.ToList(),
                recipe.IsFavorite);
    }
        
    public record DifficultyDto(int Id, string Name);
    public record MealTypeDto(int Id, string Name);
    public record DietaryOptionDto(int Id, string Name);
    public record CuisineTypeDto(int Id, string Name);
}
