using MediatR;
using MSRP.Application.DTOs.RecipeDto;

namespace MSRP.Application.Queries.Recipes.GetRecipesByCuisine;

public sealed record GetRecipesByCuisineQuery(int CuisineId) : IRequest<List<RecipeDto>?>;