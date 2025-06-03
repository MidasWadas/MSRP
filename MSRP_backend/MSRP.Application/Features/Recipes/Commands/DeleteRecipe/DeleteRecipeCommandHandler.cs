using MediatR;
using MSRP.Application.Features.Recipes.Interface;

namespace MSRP.Application.Features.Recipes.Commands.DeleteRecipe;

public class DeleteRecipeCommandHandler(IRecipesRepository repository) 
    : IRequestHandler<DeleteRecipeCommand, bool>
{
    public async Task<bool> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteRecipeAsync(request.Id, cancellationToken);
        return result;
    }
}