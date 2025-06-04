using MediatR;
using MSRP.Application.Features.Recipes.DTO;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Application.Features.Recipes.Queries.GetRecipe.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipe.Query;

public class GetRecipeQueryHandler(IRecipesRepository repository)
    : IRequestHandler<GetRecipeQuery, GetRecipeResponse>
{
    public async Task<GetRecipeResponse> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
    {
        var recipe = await repository.GetRecipeByIdAsync(request.Id, cancellationToken);
        
        return new GetRecipeResponse(recipe);
    }
}