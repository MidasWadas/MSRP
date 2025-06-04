using MediatR;
using MSRP.Application.Features.Recipes.DTO;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Domain.Recipe;

namespace MSRP.Application.Features.Recipes.Commands.UpdateRecipe;

public class UpdateRecipeCommandHandler(IRecipesRepository recipesRepository) 
    : IRequestHandler<UpdateRecipeCommand, RecipeDto?>
{
    public async Task<RecipeDto?> Handle(UpdateRecipeCommand command, CancellationToken cancellationToken)
    {
        var recipe = new Recipe(
            command.Id,
            command.Title,
            command.Description,
            command.ImageUrl,
            command.PrepTime,
            command.CookTime,
            command.Servings,
            command.RecipeDifficultyId,
            command.RecipeCuisineId,
            command.RecipeMealTypeId,
            command.DietariesIds,
            command.Ingredients,
            command.Instructions,
            command.UpdatedByUserId
        );
        var updatedRecipeId = await recipesRepository.UpdateRecipeAsync(command.Id, recipe, cancellationToken);
        
        if (updatedRecipeId > 0)
            return await recipesRepository.GetRecipeByIdAsync(updatedRecipeId, cancellationToken);
        
        throw new Exception("Failed to update recipe");
    }
}