using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.API.Features.Recipe.Requests.CreateRecipe;
using MSRP.API.Features.Recipe.Requests.GetRecipe;
using MSRP.API.Features.Recipe.Requests.UpdateRecipe;
using MSRP.Application.Features.Recipes.Commands.CreateRecipe.Command;
using MSRP.Application.Features.Recipes.Commands.CreateRecipe.Response;
using MSRP.Application.Features.Recipes.Commands.DeleteRecipe.Command;
using MSRP.Application.Features.Recipes.Commands.DeleteRecipe.Response;
using MSRP.Application.Features.Recipes.Commands.UpdateRecipe.Command;
using MSRP.Application.Features.Recipes.Commands.UpdateRecipe.Response;
using MSRP.Application.Features.Recipes.DTO;
using MSRP.Application.Features.Recipes.Queries.GetFavoriteRecipes.Query;
using MSRP.Application.Features.Recipes.Queries.GetRecipe.Query;
using MSRP.Application.Features.Recipes.Queries.GetRecipe.Response;
using MSRP.Application.Features.Recipes.Queries.GetRecipes.Query;
using MSRP.Application.Features.Recipes.Queries.GetRecipes.Response;
using MSRP.Application.Features.Recipes.Queries.GetRecipesByCuisine.Query;
using MSRP.Application.Features.Recipes.Queries.GetRecipesByDietary.Query;
using MSRP.Application.Features.Recipes.Queries.GetRecipesByMealType.Query;

namespace MSRP.API.Features.Recipe.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipesController(IMediator mediator) : ControllerBase
	{
		[HttpGet("get-recipes")]
		[ProducesResponseType<GetRecipesResponse>(StatusCodes.Status200OK)]
		public async Task<ActionResult<GetRecipesResponse>> GetRecipes()
		{
			return Ok(await mediator.Send(new GetRecipesQuery()));
		}

		[HttpGet("get-recipe")]
		[ProducesResponseType<GetRecipeResponse>(StatusCodes.Status200OK)]
		public async Task<ActionResult<GetRecipeResponse>> GetRecipe([FromQuery] GetRecipeRequest request)
		{
			var recipe = await mediator.Send(new GetRecipeQuery(request.Id));
			if (recipe.Recipe == null)
				return NotFound();
				
			return Ok(recipe);
		}

		[HttpPost("create-recipe")]
		[ProducesResponseType<CreateRecipeResponse>(StatusCodes.Status201Created)]
		public async Task<ActionResult<CreateRecipeResponse>> CreateRecipe([FromBody] CreateRecipeRequest request)
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
				request.CreatedByUserId
				));
			
			return Created($"/api/recipes/get-recipe?id={result.RecipeDto?.Id}", result);
		}
		
		[HttpPut("update-recipe/{id:int}")]
		[ProducesResponseType<UpdateRecipeResponse>(StatusCodes.Status200OK)]
		public async Task<ActionResult<UpdateRecipeResponse>> UpdateRecipe(int id, UpdateRecipeRequest request)
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
		[ProducesResponseType<DeleteRecipeResponse>(StatusCodes.Status200OK)]
		public async Task<IActionResult> DeleteRecipe(int id)
		{
			await mediator.Send(new DeleteRecipeCommand(id));
			return Ok();
		}
		
		[HttpGet("get-recipes-by-cuisine/{cuisineId:int}")]
		[ProducesResponseType<GetRecipesResponse>(StatusCodes.Status200OK)]
		public async Task<ActionResult<GetRecipesResponse>> GetRecipesByCuisine(int cuisineId)
		{
			return Ok(await mediator.Send(new GetRecipesByCuisineQuery(cuisineId)));
		}
		
		[HttpGet("get-recipes-by-meal-type/{mealTypeId:int}")]
		[ProducesResponseType<GetRecipesResponse>(StatusCodes.Status200OK)]
		public async Task<ActionResult<GetRecipesResponse>> GetRecipesByMealType(int mealTypeId)
		{
			return Ok(await mediator.Send(new GetRecipesByMealTypeQuery(mealTypeId)));
		}
		
		[HttpGet("get-recipes-by-dietary/{dietaryId:int}")]
		[ProducesResponseType<GetRecipesResponse>(StatusCodes.Status200OK)]
		public async Task<ActionResult<GetRecipesResponse>> GetRecipesByDietary(int dietaryId)
		{
			return Ok(await mediator.Send(new GetRecipesByDietaryQuery(dietaryId)));
		}
		
		[HttpGet("get-favorite-recipes")]
		[ProducesResponseType<GetRecipesResponse>(StatusCodes.Status200OK)]
		public async Task<ActionResult<GetRecipesResponse>> GetFavoriteRecipes()
		{
			return Ok(await mediator.Send(new GetFavoriteRecipesQuery()));
		}
	}
}