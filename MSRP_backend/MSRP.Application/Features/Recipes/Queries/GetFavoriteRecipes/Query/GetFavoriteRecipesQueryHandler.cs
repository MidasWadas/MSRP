using MediatR;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Application.Features.Recipes.Queries.GetFavoriteRecipes.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetFavoriteRecipes.Query;

public class GetFavoriteRecipesQueryHandler(IRecipesRepository repository)
    : IRequestHandler<GetFavoriteRecipesQuery, GetFavouriteRecipesResponse>
{
    public async Task<GetFavouriteRecipesResponse> Handle(GetFavoriteRecipesQuery request, CancellationToken cancellationToken)
    {
        // var recipes = await repository.GetFavoriteRecipesAsync(cancellationToken);
        //
        // return recipes?.Select(RecipeDto.FromRecipe).ToList();

        return new GetFavouriteRecipesResponse(null);
    }
}