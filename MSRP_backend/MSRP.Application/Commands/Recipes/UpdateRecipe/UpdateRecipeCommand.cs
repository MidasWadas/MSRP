using MediatR;
using MSRP.Application.DTOs.RecipeDto;

namespace MSRP.Application.Commands.Recipes.UpdateRecipe;

public sealed record UpdateRecipeCommand(RecipeDto Recipe) : IRequest<RecipeDto>;