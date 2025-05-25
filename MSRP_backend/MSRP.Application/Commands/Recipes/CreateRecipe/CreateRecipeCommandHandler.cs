using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.Generator;
using MSRP.Application.Interfaces.RecipeRepository;
using MSRP.Domain.Entities.Recipe;

namespace MSRP.Application.Commands.Recipes.CreateRecipe;

public class CreateRecipeCommandHandler(IRecipeRepository recipeRepository, IGenerator generator)
    : IRequestHandler<CreateRecipeCommand, RecipeDto>
{
    public async Task<RecipeDto> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var nextRecipeId = await generator.GenerateNextRecipeIdAsync(cancellationToken);
        
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
                
        var createdRecipe = await recipeRepository.CreateRecipeAsync(recipe, cancellationToken);
        
        return RecipeDto.FromRecipe(createdRecipe);
    }
}