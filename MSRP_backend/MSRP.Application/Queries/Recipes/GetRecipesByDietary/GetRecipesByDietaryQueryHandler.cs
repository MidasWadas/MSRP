using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.RecipeRepository;

namespace MSRP.Application.Queries.Recipes.GetRecipesByDietary;

public class GetRecipesByDietaryQueryHandler(IRecipeRepository repository)
    : IRequestHandler<GetRecipesByDietaryQuery, List<RecipeDto>?>
{
    public async Task<List<RecipeDto>?> Handle(GetRecipesByDietaryQuery request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetRecipesByDietaryIdAsync(request.DietaryId, cancellationToken);

        return recipes?.Select(RecipeDto.FromRecipe).ToList();
    }
}