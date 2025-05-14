using System.ComponentModel.DataAnnotations;

namespace MSRP.Models.Recipes
{
	public class MealRecepie
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public string ImageUrl { get; set; }

		public int PrepTime { get; set; }
		public int CookTime { get; set; }
		public int Servings { get; set; }

		[Required]
		public MealRecipe_Difficulty Difficulty { get; set; }

		[Required]
		public MealRecipe_CuisineType CuisineType { get; set; }

		[Required]
		public MealRecipe_MealType MealType { get; set; }

		[Required]
		public List<MealRecipe_DietaryOption> Dietaries { get; set; } = new List<MealRecipe_DietaryOption>();

		[Required]
		public List<string> Ingredients { get; set; } = new List<string>();

		[Required]
		public List<string> Instruction { get; set; } = new List<string>();

		public bool IsFavorite { get; set; }

		public sealed record MealRecipe_Difficulty(int Id, string Name);
		public sealed record MealRecipe_MealType(int Id, string Name);
		public sealed record MealRecipe_DietaryOption(int Id, string Name);
		public sealed record MealRecipe_CuisineType(int Id, string Name);
	}
}
