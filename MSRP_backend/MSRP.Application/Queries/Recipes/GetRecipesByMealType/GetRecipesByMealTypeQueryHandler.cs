using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.RecipeRepository;

namespace MSRP.Application.Queries.Recipes.GetRecipesByMealType;

public class GetRecipesByMealTypeQueryHandler(IRecipeRepository repository)
    : IRequestHandler<GetRecipesByMealTypeQuery, List<RecipeDto>?>
{
    public async Task<List<RecipeDto>?> Handle(GetRecipesByMealTypeQuery request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetRecipesByMealTypeIdAsync(request.MealTypeId, cancellationToken);

        return recipes?.Select(RecipeDto.FromRecipe).ToList();
    }
    
}