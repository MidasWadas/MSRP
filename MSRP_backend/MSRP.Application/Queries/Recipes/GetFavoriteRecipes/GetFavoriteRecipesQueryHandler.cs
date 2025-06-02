using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.RecipeRepository;

namespace MSRP.Application.Queries.Recipes.GetFavoriteRecipes;

public class GetFavoriteRecipesQueryHandler(IRecipeRepository repository)
    : IRequestHandler<GetFavoriteRecipesQuery, List<RecipeDto>?>
{
    public async Task<List<RecipeDto>?> Handle(GetFavoriteRecipesQuery request, CancellationToken cancellationToken)
    {
        // var recipes = await repository.GetFavoriteRecipesAsync(cancellationToken);
        //
        // return recipes?.Select(RecipeDto.FromRecipe).ToList();

        return null;
    }
}