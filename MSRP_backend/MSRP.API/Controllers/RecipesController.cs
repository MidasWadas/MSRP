using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.API.Requests.Recipe.CreateRecipe;
using MSRP.API.Requests.Recipe.GetRecipe;
using MSRP.Application.Commands.Recipes.CreateRecipe;
using MSRP.Application.Commands.Recipes.DeleteRecipe;
using MSRP.Application.Commands.Recipes.UpdateRecipe;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Queries.Recipes.GetFavoriteRecipes;
using MSRP.Application.Queries.Recipes.GetRecipe;
using MSRP.Application.Queries.Recipes.GetRecipes;
using MSRP.Application.Queries.Recipes.GetRecipesByCuisine;
using MSRP.Application.Queries.Recipes.GetRecipesByDietary;
using MSRP.Application.Queries.Recipes.GetRecipesByMealType;

namespace MSRP.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipesController(IMediator mediator) : ControllerBase
	{
		[HttpGet("get-recipes")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipes()
		{
			return Ok(await mediator.Send(new GetRecipesQuery()));
		}

		[HttpGet("get-recipe")]
		public async Task<ActionResult<RecipeDto>> GetRecipe([FromQuery] GetRecipeRequest request)
		{
			var recipe = await mediator.Send(new GetRecipeQuery(request.Id));
			if (recipe == null)
				return NotFound();
				
			return recipe;
		}

		[HttpPost("create-recipe")]
		public async Task<ActionResult<RecipeDto>> CreateRecipe([FromBody] CreateRecipeRequest request)
		{
			var result = await mediator.Send(new CreateRecipeCommand(
				request.Title,
				request.Description,
				request.ImageUrl,
				request.PrepTime,
				request.CookTime,
				request.Servings,
				new CreateRecipeCommand_RecipeDifficulty(request.Difficulty.Id, request.Difficulty.Name),
				new CreateRecipeCommand_RecipeCuisineType(request.CuisineType.Id, request.CuisineType.Name),
				new CreateRecipeCommand_RecipeMealType(request.MealType.Id, request.MealType.Name),
				request.Dietaries.Select(d => 
					new CreateRecipeCommand_RecipeDietaryOption(d.Id, d.Name)).ToList(),
				request.Ingredients,
				request.Instructions,
				request.IsFavorite
				));
			
			return CreatedAtAction("GetRecipe", new { id = result.Id }, result);
		}
		
		[HttpPut("update-recipe/{id:int}")]
		public async Task<IActionResult> UpdateRecipe(int id, RecipeDto recipe)
		{
			if (id != recipe.Id)
				return BadRequest();
			
			var result = await mediator.Send(new UpdateRecipeCommand(recipe));
			
			return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
		}
		
		[HttpDelete("delete-recipe/{id:int}")]
		public async Task<IActionResult> DeleteRecipe(int id)
		{
			var deleted = await mediator.Send(new DeleteRecipeCommand(id));
			
			if (deleted)
				return NoContent();
			
			return NotFound();
		}
		
		[HttpGet("get-recipes-by-cuisine/{cuisineId:int}")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipesByCuisine(int cuisineId)
		{
			return Ok(await mediator.Send(new GetRecipesByCuisineQuery(cuisineId)));
		}
		
		[HttpGet("get-recipes-by-mealtype/{mealTypeId:int}")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipesByMealType(int mealTypeId)
		{
			return Ok(await mediator.Send(new GetRecipesByMealTypeQuery(mealTypeId)));
		}
		
		[HttpGet("get-recipes-by-dietary/{dietaryId:int}")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipesByDietary(int dietaryId)
		{
			return Ok(await mediator.Send(new GetRecipesByDietaryQuery(dietaryId)));
		}
		
		[HttpGet("get-favorite-recipes")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetFavoriteRecipes()
		{
			return Ok(await mediator.Send(new GetFavoriteRecipesQuery()));
		}
	}
}