using MSRP.Domain.Entities.Recipe.ValueObjects;

namespace MSRP.Domain.Entities.Recipe
{
	public sealed record Recipe(
		int Id,
		string Title,
		string Description,
		string ImageUrl,
		int PrepTime,
		int CookTime,
		int Servings,
		int DifficultyId,
		int CuisineId,
		int MealTypeId,
		List<int> DietariesIds,
		List<string> Ingredients,
		List<string> Instructions,
		bool IsFavorite
	);
}