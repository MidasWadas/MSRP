using MSRP.Domain.Entities.Recipe;
using MSRP.Domain.Entities.Recipe.ValueObjects;

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
        RecipeDifficultyDto recipeDifficulty,
        RecipeCuisineTypeDto recipeCuisineType,
        RecipeMealTypeDto recipeMealType,
        List<RecipeDietaryOptionDto> dietaries,
        List<string> ingredients,
        List<string> instructions,
        bool isFavourite
        )
    {
        public int Id { get; init; } = id;
        public string Title { get; init; } = title;
        public string Description { get; init; } = description;
        public string ImageUrl { get; init; } = imageUrl;
        public int PrepTime { get; init; } = prepTime;
        public int CookTime { get; init; } = cookTime;
        public int Servings { get; init; } = servings;
        public RecipeDifficultyDto RecipeDifficulty { get; init; } = recipeDifficulty;
        public RecipeCuisineTypeDto RecipeCuisineType { get; init; } = recipeCuisineType;
        public RecipeMealTypeDto RecipeMealType { get; init; } = recipeMealType;
        public List<RecipeDietaryOptionDto> Dietaries { get; init; } = dietaries;
        public List<string> Ingredients { get; init; } = ingredients;
        public List<string> Instructions { get; init; } = instructions;
        public bool IsFavorite { get; init; } = isFavourite;

        public static RecipeDto FromRecipe(Recipe recipe) =>
            new(
                recipe.Id,
                recipe.Title,
                recipe.Description,
                recipe.ImageUrl,
                recipe.PrepTime,
                recipe.CookTime,
                recipe.Servings,
                new RecipeDifficultyDto(recipe.Difficulty.Id, recipe.Difficulty.Name),
                new RecipeCuisineTypeDto(recipe.CuisineType.Id, recipe.CuisineType.Name),
                new RecipeMealTypeDto(recipe.MealType.Id, recipe.MealType.Name),
                recipe.Dietaries.Select(d => new RecipeDietaryOptionDto(d.Id, d.Name)).ToList(),
                recipe.Ingredients.ToList(),
                recipe.Instructions.ToList(),
                recipe.IsFavorite);
        
        public static Recipe ToRecipe(RecipeDto recipeDto) =>
            new(
                recipeDto.Id,
                recipeDto.Title,
                recipeDto.Description,
                recipeDto.ImageUrl,
                recipeDto.PrepTime,
                recipeDto.CookTime,
                recipeDto.Servings,
                new RecipeDifficulty(recipeDto.RecipeDifficulty.Id, recipeDto.RecipeDifficulty.Name),
                new RecipeCuisineType(recipeDto.RecipeCuisineType.Id, recipeDto.RecipeCuisineType.Name),
                new RecipeMealType(recipeDto.RecipeMealType.Id, recipeDto.RecipeMealType.Name),
                recipeDto.Dietaries.Select(d => new RecipeDietaryOption(d.Id, d.Name)).ToList(),
                recipeDto.Ingredients.ToList(),
                recipeDto.Instructions.ToList(),
                recipeDto.IsFavorite
                );
    }
        
    public record RecipeDifficultyDto(int Id, string Name);
    public record RecipeMealTypeDto(int Id, string Name);
    public record RecipeDietaryOptionDto(int Id, string Name);
    public record RecipeCuisineTypeDto(int Id, string Name);
}
