using MediatR;

namespace MSRP.Application.Features.Recipes.Commands.DeleteRecipe;

public record DeleteRecipeCommand(int Id) : IRequest<bool>;