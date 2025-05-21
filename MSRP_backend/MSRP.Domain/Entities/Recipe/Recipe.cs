using MSRP.Domain.Entities.Recipe.ValueObjects;

namespace MSRP.Domain.Entities.Recipe
{
	public class Recipe(
		int id,
		string title,
		string description,
		string imageUrl,
		int prepTime,
		int cookTime,
		int servings,
		RecipeDifficulty difficulty,
		RecipeCuisineType cuisineType,
		RecipeMealType mealType,
		List<RecipeDietaryOption> dietaries,
		List<string> ingredients,
		List<string> instruction,
		bool isFavorite
		)
	{
		public int Id { get; set; } = id;

		public string Title { get; set; } = title;

		public string Description { get; set; } = description;

		public string ImageUrl { get; set; } = imageUrl;

		public int PrepTime { get; set; } = prepTime;
		
		public int CookTime { get; set; } = cookTime;
		
		public int Servings { get; set; } = servings;

		public RecipeDifficulty Difficulty { get; set; } = difficulty;

		public RecipeCuisineType CuisineType { get; set; } = cuisineType;

		public RecipeMealType MealType { get; set; } = mealType;

		public List<RecipeDietaryOption> Dietaries { get; set; } = dietaries;

		public List<string> Ingredients { get; set; } = ingredients;

		public List<string> Instructions { get; set; } = instruction;

		public bool IsFavorite { get; set; } = isFavorite;
	}
}
