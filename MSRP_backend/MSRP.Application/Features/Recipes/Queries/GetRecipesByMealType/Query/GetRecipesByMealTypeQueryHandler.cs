using MediatR;
using MSRP.Application.Features.Recipes.DTO;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Application.Features.Recipes.Queries.GetRecipesByMealType.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipesByMealType.Query;

public class GetRecipesByMealTypeQueryHandler(IRecipesRepository repository)
    : IRequestHandler<GetRecipesByMealTypeQuery, GetRecipesByMealTypeResponse>
{
    public async Task<GetRecipesByMealTypeResponse> Handle(GetRecipesByMealTypeQuery request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetByMealTypeIdAsync(request.MealTypeId, cancellationToken);

        return new GetRecipesByMealTypeResponse(recipes);
    }
    
}