using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Interfaces.RecipeRepository;

namespace MSRP.Application.Commands.Recipes.CreateRecipe;

public class CreateRecipeCommandHandler(IRecipeRepository recipeRepository)
    : IRequestHandler<CreateRecipeCommand, RecipeDto>
{
    public async Task<RecipeDto> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var createdRecipe = await recipeRepository.CreateRecipeAsync(
            request.Title,
            request.Description,
            request.ImageUrl,
            request.PrepTime,
            request.CookTime,
            request.Servings,
            request.RecipeDifficulty,
            request.RecipeCuisineType,
            request.RecipeMealType,
            request.Dietaries,
            request.Ingredients,
            request.Instructions,
            request.IsFavorite,
            cancellationToken);
        
        return RecipeDto.FromRecipe(createdRecipe);
    }
}