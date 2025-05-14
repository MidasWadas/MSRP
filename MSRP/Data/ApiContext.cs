using Microsoft.EntityFrameworkCore;
using MSRP.Models.Recipes;
using System.Text.Json;

namespace MSRP.Data
{
	public class ApiContext : DbContext
	{
		public DbSet<MealRecepie> Recepies { get; set; }
		public DbSet<CuisineOption> CuisineOptions { get; set; }
		public DbSet<MealType> MealTypeOptions { get; set; }
		public DbSet<DietaryOption> DietaryOptions { get; set; }
		public DbSet<DifficultyOption> DifficultyOptions { get; set; }

		public ApiContext(DbContextOptions<ApiContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.HasDefaultSchema("public");

			modelBuilder.Entity<MealRecepie>(entity =>
			{
				entity.Property(p => p.Ingredients)
					.HasConversion(
						v => string.Join(';', v),
						v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

				entity.Property(p => p.Instruction)
					.HasConversion(
						v => string.Join(';', v),
						v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

				entity.Property(p => p.Difficulty)
					.HasColumnType("jsonb")
					.HasConversion(
						v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
						v => JsonSerializer.Deserialize<MealRecepie.MealRecipe_Difficulty>(v, (JsonSerializerOptions)null));

				entity.Property(p => p.CuisineType)
					.HasColumnType("jsonb")
					.HasConversion(
						v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
						v => JsonSerializer.Deserialize<MealRecepie.MealRecipe_CuisineType>(v, (JsonSerializerOptions)null));

				entity.Property(p => p.MealType)
					.HasColumnType("jsonb")
					.HasConversion(
						v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
						v => JsonSerializer.Deserialize<MealRecepie.MealRecipe_MealType>(v, (JsonSerializerOptions)null));

				entity.Property(p => p.Dietaries)
					.HasColumnType("jsonb")
					.HasConversion(
						v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
						v => JsonSerializer.Deserialize<List<MealRecepie.MealRecipe_DietaryOption>>(v, (JsonSerializerOptions)null));
			});

			modelBuilder.Entity<CuisineOption>().HasData(
				new CuisineOption { Id = 1, Name = "Italian", Description = "Italian cuisine" },
				new CuisineOption { Id = 2, Name = "Mexican", Description = "Mexican cuisine" },
				new CuisineOption { Id = 3, Name = "Japanese", Description = "Japanese cuisine" },
				new CuisineOption { Id = 4, Name = "Indian", Description = "Indian cuisine" },
				new CuisineOption { Id = 5, Name = "Mediterranean", Description = "Mediterranean cuisine" }
			);

			modelBuilder.Entity<MealType>().HasData(
				new MealType { Id = 1, Name = "Breakfast" },
				new MealType { Id = 2, Name = "Lunch" },
				new MealType { Id = 3, Name = "Dinner" },
				new MealType { Id = 4, Name = "Snack" },
				new MealType { Id = 5, Name = "Dessert" }
			);

			modelBuilder.Entity<DietaryOption>().HasData(
				new DietaryOption { Id = 1, Name = "Vegetarian", Description = "No meat, poultry, or seafood" },
				new DietaryOption { Id = 2, Name = "Vegan", Description = "No animal products" },
				new DietaryOption { Id = 3, Name = "Gluten-Free", Description = "No gluten-containing ingredients" },
				new DietaryOption { Id = 4, Name = "Dairy-Free", Description = "No dairy products" }
			);

			modelBuilder.Entity<DifficultyOption>().HasData(
			new DifficultyOption { Id = 1, Name = "Easy" },
			new DifficultyOption { Id = 2, Name = "Medium" },
			new DifficultyOption { Id = 3, Name = "Hard" }
		);
		}
	}
}
