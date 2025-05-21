using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.RecipeRepository;

namespace MSRP.Application.Commands.Recipes.UpdateRecipe;

public class UpdateRecipeCommandHandler(IRecipeRepository recipeRepository) 
    : IRequestHandler<UpdateRecipeCommand, RecipeDto>
{
    public async Task<RecipeDto> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = RecipeDto.ToRecipe(request.Recipe);
        var updatedRecipe = await recipeRepository.UpdateRecipeAsync(recipe, cancellationToken);
        
        return RecipeDto.FromRecipe(updatedRecipe);
    }
}