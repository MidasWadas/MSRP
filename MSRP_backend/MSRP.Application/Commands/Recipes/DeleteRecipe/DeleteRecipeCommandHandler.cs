using MediatR;
using MSRP.Application.Interfaces.RecipeRepository;

namespace MSRP.Application.Commands.Recipes.DeleteRecipe;

public class DeleteRecipeCommandHandler(IRecipeRepository repository) 
    : IRequestHandler<DeleteRecipeCommand, bool>
{
    public async Task<bool> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteRecipeAsync(request.Id, cancellationToken);
        return result;
    }
}