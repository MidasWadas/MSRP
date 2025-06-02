using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.RecipeRepository;
using MSRP.Application.Queries.Recipes.GetRecipes.Response;

namespace MSRP.Application.Queries.Recipes.GetRecipes.Query;

public class GetRecipesQueryHandler(IRecipeRepository repository)
    : IRequestHandler<GetRecipesQuery, GetRecipesResponse>
{
    public async Task<GetRecipesResponse> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetRecipesAsync(cancellationToken);
        
        return new GetRecipesResponse() { Recipes = recipes.Select(RecipeDto.FromRecipe).ToList() };
    }
}