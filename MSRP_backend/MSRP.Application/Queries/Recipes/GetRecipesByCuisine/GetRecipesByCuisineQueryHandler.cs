using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.RecipeRepository;

namespace MSRP.Application.Queries.Recipes.GetRecipesByCuisine;

public class GetRecipesByCuisineQueryHandler(IRecipeRepository repository)
: IRequestHandler<GetRecipesByCuisineQuery, List<RecipeDto>?>
{
    public async Task<List<RecipeDto>?> Handle(GetRecipesByCuisineQuery request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetRecipesByCuisineIdAsync(request.CuisineId, cancellationToken);

        return recipes?.Select(RecipeDto.FromRecipe).ToList();
    }
}