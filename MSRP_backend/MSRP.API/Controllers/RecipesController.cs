using MediatR;
using Microsoft.AspNetCore.Mvc;
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
		[HttpGet("get")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipes()
		{
			return Ok(await mediator.Send(new GetRecipesQuery()));
		}

		[HttpGet("get/{id:int}")]
		public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
		{
			var mealRecepie = await mediator.Send(new GetRecipeQuery(id));
			if (mealRecepie == null)
			{
				return NotFound();
			}
			return mealRecepie;
		}

		[HttpPost("add")]
		public async Task<ActionResult<RecipeDto>> AddRecipe(RecipeDto? recipe)
		{
			if (recipe == null)
				return BadRequest();
			
			var result = await mediator.Send(new CreateRecipeCommand(recipe));
			
			return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
		}
		
		[HttpPut("update/{id:int}")]
		public async Task<IActionResult> UpdateRecipe(int id, RecipeDto recipe)
		{
			if (id != recipe.Id)
				BadRequest();
			
			var result = await mediator.Send(new UpdateRecipeCommand(recipe));
			
			return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
		}
		
		[HttpDelete("delete/{id:int}")]
		public async Task<IActionResult> DeleteRecipe(int id)
		{
			var deleted = await mediator.Send(new DeleteRecipeCommand(id));
			
			if (deleted)
				return NoContent();
			
			return NotFound();
		}
		
		[HttpGet("cuisine/{cuisineId:int}")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipesByCuisine(int cuisineId)
		{
			return Ok(await mediator.Send(new GetRecipesByCuisineQuery(cuisineId)));
		}
		
		[HttpGet("mealtype/{mealTypeId:int}")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipesByMealType(int mealTypeId)
		{
			return Ok(await mediator.Send(new GetRecipesByMealTypeQuery(mealTypeId)));
		}
		
		[HttpGet("dietary/{dietaryId:int}")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipesByDietary(int dietaryId)
		{
			return Ok(await mediator.Send(new GetRecipesByDietaryQuery(dietaryId)));
		}
		
		[HttpGet("favorites")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetFavoriteRecipes()
		{
			return Ok(await mediator.Send(new GetFavoriteRecipesQuery()));
		}
	}
}