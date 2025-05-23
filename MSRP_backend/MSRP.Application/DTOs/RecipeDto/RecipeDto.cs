using MSRP.Domain.Entities.Recipe;
using MSRP.Domain.Entities.Recipe.ValueObjects;

namespace MSRP.Application.DTOs.RecipeDto
{
    public sealed record RecipeDto(
        int Id,
        string Title,
        string Description,
        string ImageUrl,
        int PrepTime,
        int CookTime,
        int Servings,
        RecipeDifficultyDto RecipeDifficulty,
        RecipeCuisineTypeDto RecipeCuisineType,
        RecipeMealTypeDto RecipeMealType,
        List<RecipeDietaryOptionDto> Dietaries,
        List<string> Ingredients,
        List<string> Instructions,
        bool IsFavorite
        )
    {
        public static RecipeDto FromRecipe(Recipe recipe) => null;
            // new(
            //     recipe.Id,
            //     recipe.Title,
            //     recipe.Description,
            //     recipe.ImageUrl,
            //     recipe.PrepTime,
            //     recipe.CookTime,
            //     recipe.Servings,
            //     new RecipeDifficultyDto(recipe.Difficulty.Id, recipe.Difficulty.Name),
            //     new RecipeCuisineTypeDto(recipe.CuisineType.Id, recipe.CuisineType.Name),
            //     new RecipeMealTypeDto(recipe.MealType.Id, recipe.MealType.Name),
            //     recipe.Dietaries.Select(d => new RecipeDietaryOptionDto(d.Id, d.Name)).ToList(),
            //     recipe.Ingredients.ToList(),
            //     recipe.Instructions.ToList(),
            //     recipe.IsFavorite);
        
        public static Recipe ToRecipe(RecipeDto recipeDto) =>
            new(
                recipeDto.Id,
                recipeDto.Title,
                recipeDto.Description,
                recipeDto.ImageUrl,
                recipeDto.PrepTime,
                recipeDto.CookTime,
                recipeDto.Servings,
                recipeDto.RecipeDifficulty.Id,
                recipeDto.RecipeCuisineType.Id,
                recipeDto.RecipeMealType.Id,
                recipeDto.Dietaries.Select(d => d.Id).ToList(),
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
