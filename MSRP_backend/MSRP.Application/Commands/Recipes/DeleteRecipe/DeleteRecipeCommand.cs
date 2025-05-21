using MediatR;

namespace MSRP.Application.Commands.Recipes.DeleteRecipe;

public record DeleteRecipeCommand(int Id) : IRequest<bool>;