using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.RecipeRepository;

namespace MSRP.Application.Queries.Recipes.GetRecipes;

public class GetRecipesQueryHandler(IRecipeRepository repository)
    : IRequestHandler<GetRecipesQuery, List<RecipeDto>>
{
    public async Task<List<RecipeDto>> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetAllRecipesAsync(cancellationToken);
        
        return recipes.Select(RecipeDto.FromRecipe).ToList();
    }
}