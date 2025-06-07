using MediatR;
using MSRP.Application.Features.Recipes.DTO;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Application.Features.Recipes.Queries.GetRecipes.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipes.Query;

public class GetRecipesQueryHandler(IRecipesRepository repository)
    : IRequestHandler<GetRecipesQuery, GetRecipesResponse>
{
    public async Task<GetRecipesResponse> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetAllAsync(cancellationToken);
        
        return new GetRecipesResponse(recipes);
    }
}