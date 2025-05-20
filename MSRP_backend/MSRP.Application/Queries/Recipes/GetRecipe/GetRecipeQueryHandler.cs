using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.RecipeRepository;

namespace MSRP.Application.Queries.Recipes.GetRecipe;

public class GetRecipeQueryHandler(IRecipeRepository recipeRepository)
    : IRequestHandler<GetRecipeQuery, RecipeDto?>
{
    public async Task<RecipeDto?> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
    {
        var recipe = await recipeRepository.GetRecipeByIdAsync(request.Id);
        
        return recipe == null ? null : RecipeDto.FromRecipe(recipe);
    }
}