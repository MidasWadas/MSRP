using MSRP.Application.DTOs.RecipeDto;

namespace MSRP.Application.Queries.Recipes.GetRecipes.Response;

public class GetRecipesResponse
{
    public List<RecipeDto> Recipes { get; set; }
}