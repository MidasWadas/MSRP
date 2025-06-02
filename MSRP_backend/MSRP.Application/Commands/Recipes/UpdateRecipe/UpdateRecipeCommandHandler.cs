using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.RecipeRepository;
using MSRP.Domain.Recipe;

namespace MSRP.Application.Commands.Recipes.UpdateRecipe;

public class UpdateRecipeCommandHandler(IRecipeRepository recipeRepository) 
    : IRequestHandler<UpdateRecipeCommand, RecipeDto>
{
    public async Task<RecipeDto> Handle(UpdateRecipeCommand command, CancellationToken cancellationToken)
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
        var updatedRecipe = await recipeRepository.UpdateRecipeAsync(command.Id, recipe, cancellationToken);
        
        return RecipeDto.FromRecipe(updatedRecipe);
    }
}