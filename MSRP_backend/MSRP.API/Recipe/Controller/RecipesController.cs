using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.API.Recipe.Requests.CreateRecipe;
using MSRP.API.Recipe.Requests.GetRecipe;
using MSRP.API.Recipe.Requests.UpdateRecipe;
using MSRP.Application.Commands.Recipes.CreateRecipe;
using MSRP.Application.Commands.Recipes.DeleteRecipe;
using MSRP.Application.Commands.Recipes.UpdateRecipe;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Queries.Recipes.GetFavoriteRecipes;
using MSRP.Application.Queries.Recipes.GetRecipe;
using MSRP.Application.Queries.Recipes.GetRecipes.Query;
using MSRP.Application.Queries.Recipes.GetRecipesByCuisine;
using MSRP.Application.Queries.Recipes.GetRecipesByDietary;
using MSRP.Application.Queries.Recipes.GetRecipesByMealType;

namespace MSRP.API.Recipe.Controller
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
				request.DifficultyId,
				request.CuisineId,
				request.MealTypeId,
				request.DietariesIds,
				request.Ingredients,
				request.Instructions,
				request.CreaterByUserId
				));
			
			return Created(result.Id.ToString(), result);
		}
		
		[HttpPut("update-recipe/{id:int}")]
		public async Task<IActionResult> UpdateRecipe(int id, UpdateRecipeRequest request)
		{
			if (id != request.Id)
				return BadRequest();
			
			var result = await mediator.Send(new UpdateRecipeCommand(
				request.Id,
				request.Title,
				request.Description,
				request.ImageUrl,
				request.PrepTime,
				request.CookTime,
				request.Servings,
				request.DifficultyId,
				request.CuisineId,
				request.MealTypeId,
				request.DietariesIds,
				request.Ingredients,
				request.Instruction,
				request.UpdatedByUserId
				));
			
			return Ok(result);
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
		
		[HttpGet("get-recipes-by-meal-type/{mealTypeId:int}")]
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