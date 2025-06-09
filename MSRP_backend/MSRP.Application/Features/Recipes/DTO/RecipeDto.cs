using MSRP.Domain.Recipe;
using MSRP.Domain.Recipe.ValueObjects;

namespace MSRP.Application.Features.Recipes.DTO
{
    public sealed record RecipeDto(
        int? Id,
        string Title,
        string Description,
        string ImageUrl,
        int PrepTime,
        int CookTime,
        int Servings,
        RecipeDifficultyDto Difficulty,
        RecipeCuisineDto Cuisine,
        RecipeMealTypeDto MealType,
        List<RecipeDietaryDto> Dietaries,
        List<string> Ingredients,
        List<string> Instructions,
        int CreatedByUserId
        )
    {
        public static RecipeDto FromRecipeWithRelatedEntities(
            Recipe recipe, 
            RecipeDifficulty difficulty, 
            RecipeCuisineType cuisineType, 
            RecipeMealType mealType, 
            IEnumerable<RecipeDietaryOption> dietaries)
        {
            return new(
                recipe.Id,
                recipe.Title,
                recipe.Description,
                recipe.ImageUrl,
                recipe.PrepTime,
                recipe.CookTime,
                recipe.Servings,
                new RecipeDifficultyDto(difficulty.Id, difficulty.Name),
                new RecipeCuisineDto(cuisineType.Id, cuisineType.Name),
                new RecipeMealTypeDto(mealType.Id, mealType.Name),
                dietaries.Select(d => new RecipeDietaryDto(d.Id, d.Name)).ToList(),
                recipe.Ingredients,
                recipe.Instructions,
                recipe.CreatedByUserId
            );
        }
        
        //I need to find a solution to grabbing records (Id and Name) from Recipe and put that in RecipeDTO
        //public static RecipeDto FromRecipe(Recipe recipe) => null;
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

            public static Recipe ToRecipe(RecipeDto recipeDto)
            {
                if(recipeDto?.Id is null)
                    throw new ArgumentNullException(nameof(recipeDto.Id), "Recipe ID cannot be null");
                
                return new(
                    recipeDto.Id.Value,
                    recipeDto.Title,
                    recipeDto.Description,
                    recipeDto.ImageUrl,
                    recipeDto.PrepTime,
                    recipeDto.CookTime,
                    recipeDto.Servings,
                    recipeDto.Difficulty.Id,
                    recipeDto.Cuisine.Id,
                    recipeDto.MealType.Id,
                    recipeDto.Dietaries.Select(d => d.Id).ToList(),
                    recipeDto.Ingredients.ToList(),
                    recipeDto.Instructions.ToList(),
                    recipeDto.CreatedByUserId
                    );
            }
    }
        
    public sealed record RecipeDifficultyDto(int Id, string Name);
    public sealed record RecipeMealTypeDto(int Id, string Name);
    public sealed record RecipeDietaryDto(int Id, string Name);
    public sealed record RecipeCuisineDto(int Id, string Name);
}
