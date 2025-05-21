using MediatR;
using MSRP.Application.DTOs.RecipeDto;

namespace MSRP.Application.Queries.Recipes.GetRecipesByDietary;

public sealed record GetRecipesByDietaryQuery(int DietaryId) : IRequest<List<RecipeDto>?>;