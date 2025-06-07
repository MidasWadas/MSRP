using MediatR;
using MSRP.Application.Features.Recipes.Commands.CreateRecipe.Response;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Application.Interfaces.Generator;
using MSRP.Domain.Recipe;

namespace MSRP.Application.Features.Recipes.Commands.CreateRecipe.Command;

public class CreateRecipeCommandHandler(IRecipesRepository recipesRepository, IGenerator generator)
    : IRequestHandler<CreateRecipeCommand, CreateRecipeResponse>
{
    public async Task<CreateRecipeResponse> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var nextRecipeId = await generator.GenerateNextIdAsync<Recipe>(cancellationToken);
        
        var recipe = new Recipe(
            nextRecipeId,
            request.Title,
            request.Description,
            request.ImageUrl,
            request.PrepTime,
            request.CookTime,
            request.Servings,
            request.RecipeDifficultyId,
            request.RecipeCuisineId,
            request.RecipeMealTypeId,
            request.DietariesIds,
            request.Ingredients,
            request.Instructions,
            request.CreatedByUserId);
                
        var createdRecipeId = await recipesRepository.CreateRecipeAsync(recipe, cancellationToken);
        
        if (createdRecipeId > 0)
            return new CreateRecipeResponse(await recipesRepository.GetRecipeByIdAsync(createdRecipeId, cancellationToken));
            
        
        throw new Exception("Failed to create recipe");
    }
}