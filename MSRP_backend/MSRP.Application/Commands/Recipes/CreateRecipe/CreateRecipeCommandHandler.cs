using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.RecipeRepository;

namespace MSRP.Application.Commands.Recipes.CreateRecipe;

public class CreateRecipeCommandHandler(IRecipeRepository recipeRepository)
    : IRequestHandler<CreateRecipeCommand, RecipeDto>
{
    public async Task<RecipeDto> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = RecipeDto.ToRecipe(request.Recipe);
        var createdRecipe = await recipeRepository.CreateRecipeAsync(recipe, cancellationToken);
        
        return await Task.FromResult(RecipeDto.FromRecipe(createdRecipe));
    }
}