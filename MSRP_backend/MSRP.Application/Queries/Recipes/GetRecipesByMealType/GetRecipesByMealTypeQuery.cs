using MediatR;
using MSRP.Application.DTOs.RecipeDto;

namespace MSRP.Application.Queries.Recipes.GetRecipesByMealType;

public sealed record GetRecipesByMealTypeQuery(int MealTypeId) : IRequest<List<RecipeDto>?>;