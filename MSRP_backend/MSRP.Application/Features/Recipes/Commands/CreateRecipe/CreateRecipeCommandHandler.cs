using MediatR;
using MSRP.Application.Features.Recipes.DTO;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Application.Interfaces.Generator;
using MSRP.Domain.Recipe;

namespace MSRP.Application.Features.Recipes.Commands.CreateRecipe;

public class CreateRecipeCommandHandler(IRecipesRepository recipesRepository, IGenerator generator)
    : IRequestHandler<CreateRecipeCommand, RecipeDto>
{
    public async Task<RecipeDto> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
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
                
        var createdRecipe = await recipesRepository.CreateRecipeAsync(recipe, cancellationToken);
        
        return RecipeDto.FromRecipe(createdRecipe);
    }
}