using MediatR;
using MSRP.Application.Features.Recipes.DTO;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Application.Features.Recipes.Queries.GetRecipesByCuisine.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipesByCuisine.Query;

public class GetRecipesByCuisineQueryHandler(IRecipesRepository repository)
: IRequestHandler<GetRecipesByCuisineQuery, GetRecipesByCuisineResponse>
{
    public async Task<GetRecipesByCuisineResponse> Handle(GetRecipesByCuisineQuery request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetByCuisineIdAsync(request.CuisineId, cancellationToken);

        return new GetRecipesByCuisineResponse(recipes);
    }
}