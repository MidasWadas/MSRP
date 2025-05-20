using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Queries.Recipes.GetRecipe;
using MSRP.Application.Queries.Recipes.GetRecipes;

namespace MSRP.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipesController(IMediator _mediator) : ControllerBase
	{
		[HttpGet("GetRecipes")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipes()
		{
			return Ok(await _mediator.Send(new GetRecipesQuery()));
		}

		[HttpGet("GetRecipe/{id}")]
		public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
		{
			var mealRecepie = await _mediator.Send(new GetRecipeQuery(id));
			if (mealRecepie == null)
			{
				return NotFound();
			}
			return mealRecepie;
		}

		// [HttpPost("AddRecipe")]
		// public async Task<ActionResult<Recipe>> AddRecipe(Recipe recipe)
		// {
		// 	context.Recepies.Add(recipe);
		// 	await context.SaveChangesAsync();
		// 	return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
		// }
		//
		// [HttpPut("UpdateRecipe/{id}")]
		// public async Task<IActionResult> UpdateRecipe(int id, Recipe recipe)
		// {
		// 	if (id != recipe.Id && context.Recepies.Any(e => e.Id == id))
		// 	{
		// 		return BadRequest();
		// 	}
		// 	context.Entry(recipe).State = EntityState.Modified;
		// 	try
		// 	{
		// 		await context.SaveChangesAsync();
		// 		return Ok();
		// 	}
		// 	catch (DbUpdateConcurrencyException)
		// 	{
		// 		return NoContent();
		// 	}
		// }
		//
		// [HttpDelete("DeleteRecipe/{id}")]
		// public async Task<IActionResult> DeleteRecipe(int id)
		// {
		// 	var mealRecepie = await context.Recepies.FindAsync(id);
		// 	if (mealRecepie == null)
		// 	{
		// 		return NotFound();
		// 	}
		// 	context.Recepies.Remove(mealRecepie);
		// 	await context.SaveChangesAsync();
		// 	return NoContent();
		// }
		//
		// [HttpGet("GetCuisineOptions")]
		// public async Task<ActionResult<IEnumerable<CuisineOption>>> GetCuisineOptions()
		// {
		// 	var options = await context.CuisineOptions.ToListAsync();
		//
		// 	return options;
		// }
		//
		// [HttpGet("GetMealTypes")]
		// public async Task<ActionResult<IEnumerable<MealType>>> GetMealTypes()
		// {
		// 	return await context.MealTypeOptions.ToListAsync();
		// }
		//
		// [HttpGet("GetDietaryOptions")]
		// public async Task<ActionResult<IEnumerable<DietaryOption>>> GetDietaryOptions()
		// {
		// 	return await context.DietaryOptions.ToListAsync();
		// }
		//
		// [HttpGet("GetDifficultyOptions")]
		// public async Task<ActionResult<IEnumerable<DifficultyOption>>> GetDifficultyOptions()
		// {
		// 	return await context.DifficultyOptions.ToListAsync();
		// }
		//
		// [HttpGet("GetRecepieByCuisine/{cuisineId}")]
		// public async Task<ActionResult<IEnumerable<Recipe>>> GetRecepieByCuisine(int cuisineId)
		// {
		// 	var mealRecepies = await context.Recepies
		// 		.Where(r => r.CuisineType.Id == cuisineId)
		// 		.ToListAsync();
		// 	if (mealRecepies == null || !mealRecepies.Any())
		// 	{
		// 		return NotFound();
		// 	}
		// 	return mealRecepies;
		// }
		//
		// [HttpGet("GetRecepieByMealType/{mealTypeId}")]
		// public async Task<ActionResult<IEnumerable<Recipe>>> GetRecepieByMealType(int mealTypeId)
		// {
		// 	var mealRecepies = await context.Recepies
		// 		.Where(r => r.MealType.Id == mealTypeId)
		// 		.ToListAsync();
		// 	if (mealRecepies == null || !mealRecepies.Any())
		// 	{
		// 		return NotFound();
		// 	}
		// 	return mealRecepies;
		// }
		//
		// [HttpGet("GetRecepieByDietary/{dietaryId}")]
		// public async Task<ActionResult<IEnumerable<Recipe>>> GetRecepieByDietary(int dietaryId)
		// {
		// 	var mealRecepies = await context.Recepies
		// 		.Where(r => r.Dietaries.Any(d => d.Id == dietaryId))
		// 		.ToListAsync();
		// 	if (mealRecepies == null || !mealRecepies.Any())
		// 	{
		// 		return NotFound();
		// 	}
		// 	return mealRecepies;
		// }
		//
		// [HttpGet("GetFavoriteRecipes")]
		// public async Task<ActionResult<IEnumerable<Recipe>>> GetFavoriteRecipes()
		// {
		// 	var mealRecepies = await context.Recepies
		// 		.Where(r => r.IsFavorite)
		// 		.ToListAsync();
		// 	if (mealRecepies == null || !mealRecepies.Any())
		// 	{
		// 		return NotFound();
		// 	}
		// 	return mealRecepies;
		// }
	}
}