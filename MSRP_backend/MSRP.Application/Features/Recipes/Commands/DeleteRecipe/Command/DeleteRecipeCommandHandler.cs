using MediatR;
using MSRP.Application.Features.Recipes.Commands.DeleteRecipe.Response;
using MSRP.Application.Features.Recipes.Interface;

namespace MSRP.Application.Features.Recipes.Commands.DeleteRecipe.Command;

public class DeleteRecipeCommandHandler(IRecipesRepository repository) 
    : IRequestHandler<DeleteRecipeCommand, DeleteRecipeResponse>
{
    public async Task<DeleteRecipeResponse> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteAsync(request.Id, cancellationToken);
        
        return result ? new DeleteRecipeResponse() : throw new Exception("Failed to delete recipe");
    }
}