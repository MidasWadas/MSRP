using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSRP.Data;
using MSRP.Models.Recipes;

namespace MSRP.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipesController : ControllerBase
	{
		private readonly ApiContext _context;
		public RecipesController(ApiContext context)
		{
			_context = context;
		}

		[HttpGet("GetRecipes")]
		public async Task<ActionResult<IEnumerable<MealRecepie>>> GetRecipes()
		{
			return await _context.Recepies.ToListAsync();
		}

		[HttpGet("GetRecipe/{id}")]
		public async Task<ActionResult<MealRecepie>> GetRecipe(int id)
		{
			var mealRecepie = await _context.Recepies.FindAsync(id);
			if (mealRecepie == null)
			{
				return NotFound();
			}
			return mealRecepie;
		}

		[HttpPost("AddRecipe")]
		public async Task<ActionResult<MealRecepie>> AddRecipe(MealRecepie mealRecepie)
		{
			_context.Recepies.Add(mealRecepie);
			await _context.SaveChangesAsync();
			return CreatedAtAction("GetRecipe", new { id = mealRecepie.Id }, mealRecepie);
		}

		[HttpPut("UpdateRecipe/{id}")]
		public async Task<IActionResult> UpdateRecipe(int id, MealRecepie mealRecepie)
		{
			if (id != mealRecepie.Id && _context.Recepies.Any(e => e.Id == id))
			{
				return BadRequest();
			}
			_context.Entry(mealRecepie).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (DbUpdateConcurrencyException)
			{
				return NoContent();
			}
		}

		[HttpDelete("DeleteRecipe/{id}")]
		public async Task<IActionResult> DeleteRecipe(int id)
		{
			var mealRecepie = await _context.Recepies.FindAsync(id);
			if (mealRecepie == null)
			{
				return NotFound();
			}
			_context.Recepies.Remove(mealRecepie);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		[HttpGet("GetCuisineOptions")]
		public async Task<ActionResult<IEnumerable<CuisineOption>>> GetCuisineOptions()
		{
			var options = await _context.CuisineOptions.ToListAsync();

			return options;
		}

		[HttpGet("GetMealTypes")]
		public async Task<ActionResult<IEnumerable<MealType>>> GetMealTypes()
		{
			return await _context.MealTypeOptions.ToListAsync();
		}

		[HttpGet("GetDietaryOptions")]
		public async Task<ActionResult<IEnumerable<DietaryOption>>> GetDietaryOptions()
		{
			return await _context.DietaryOptions.ToListAsync();
		}

		[HttpGet("GetDifficultyOptions")]
		public async Task<ActionResult<IEnumerable<DifficultyOption>>> GetDifficultyOptions()
		{
			return await _context.DifficultyOptions.ToListAsync();
		}

		[HttpGet("GetRecepieByCuisine/{cuisineId}")]
		public async Task<ActionResult<IEnumerable<MealRecepie>>> GetRecepieByCuisine(int cuisineId)
		{
			var mealRecepies = await _context.Recepies
				.Where(r => r.CuisineType.Id == cuisineId)
				.ToListAsync();
			if (mealRecepies == null || !mealRecepies.Any())
			{
				return NotFound();
			}
			return mealRecepies;
		}

		[HttpGet("GetRecepieByMealType/{mealTypeId}")]
		public async Task<ActionResult<IEnumerable<MealRecepie>>> GetRecepieByMealType(int mealTypeId)
		{
			var mealRecepies = await _context.Recepies
				.Where(r => r.MealType.Id == mealTypeId)
				.ToListAsync();
			if (mealRecepies == null || !mealRecepies.Any())
			{
				return NotFound();
			}
			return mealRecepies;
		}

		[HttpGet("GetRecepieByDietary/{dietaryId}")]
		public async Task<ActionResult<IEnumerable<MealRecepie>>> GetRecepieByDietary(int dietaryId)
		{
			var mealRecepies = await _context.Recepies
				.Where(r => r.Dietaries.Any(d => d.Id == dietaryId))
				.ToListAsync();
			if (mealRecepies == null || !mealRecepies.Any())
			{
				return NotFound();
			}
			return mealRecepies;
		}

		[HttpGet("GetFavoriteRecipes")]
		public async Task<ActionResult<IEnumerable<MealRecepie>>> GetFavoriteRecipes()
		{
			var mealRecepies = await _context.Recepies
				.Where(r => r.IsFavorite)
				.ToListAsync();
			if (mealRecepies == null || !mealRecepies.Any())
			{
				return NotFound();
			}
			return mealRecepies;
		}
	}
}