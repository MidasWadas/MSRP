using MediatR;
using MSRP.Application.DTOs.RecipeDto;

namespace MSRP.Application.Queries.Recipes.GetRecipe;

public sealed record GetRecipeQuery(int Id) : IRequest<RecipeDto?>;