using MediatR;
using MSRP.Application.DTOs.RecipeDto;

namespace MSRP.Application.Commands.Recipes.CreateRecipe;

public sealed record CreateRecipeCommand(RecipeDto Recipe) : IRequest<RecipeDto>;