using MediatR;
using MSRP.Application.DTOs.RecipeDto;

namespace MSRP.Application.Queries.Recipes.GetRecipes;

public sealed record GetRecipesQuery() : IRequest<List<RecipeDto>>;