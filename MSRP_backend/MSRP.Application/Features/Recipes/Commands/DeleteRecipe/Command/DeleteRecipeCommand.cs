using MediatR;
using MSRP.Application.Features.Recipes.Commands.DeleteRecipe.Response;

namespace MSRP.Application.Features.Recipes.Commands.DeleteRecipe.Command;

public record DeleteRecipeCommand(int Id) : IRequest<DeleteRecipeResponse>;