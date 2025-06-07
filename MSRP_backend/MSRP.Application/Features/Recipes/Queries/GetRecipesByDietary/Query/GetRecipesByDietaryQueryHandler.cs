using MediatR;
using MSRP.Application.Features.Recipes.DTO;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Application.Features.Recipes.Queries.GetRecipesByDietary.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipesByDietary.Query;

public class GetRecipesByDietaryQueryHandler(IRecipesRepository repository)
    : IRequestHandler<GetRecipesByDietaryQuery, GetRecipesByDietaryResponse>
{
    public async Task<GetRecipesByDietaryResponse> Handle(GetRecipesByDietaryQuery request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetByDietaryIdAsync(request.DietaryId, cancellationToken);

        return new GetRecipesByDietaryResponse(recipes);
    }
}