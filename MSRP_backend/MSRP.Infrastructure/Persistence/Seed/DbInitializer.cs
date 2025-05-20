using Microsoft.EntityFrameworkCore;
using MSRP.Domain.Entities.CuisineOption;
using MSRP.Domain.Entities.DietaryOption;
using MSRP.Domain.Entities.DifficultyOption;
using MSRP.Domain.Entities.MealType;

namespace MSRP.Infrastructure.Persistence.Seed;

public class DbInitializer
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        SeedCuisineOptions(modelBuilder);
        SeedMealTypes(modelBuilder);
        SeedDietaryOptions(modelBuilder);
        SeedDifficultyOptions(modelBuilder);
    }

    private static void SeedCuisineOptions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CuisineOption>().HasData(
            new CuisineOption(id: 1, name: "Italian", description: "Italian cuisine"),
            new CuisineOption(id: 2, name: "Mexican", description: "Mexican cuisine"),
            new CuisineOption(id: 3, name: "Japanese", description: "Japanese cuisine"),
            new CuisineOption(id: 4, name: "Indian", description: "Indian cuisine"),
            new CuisineOption(id: 5, name: "Mediterranean", description: "Mediterranean cuisine")
        );
    }
    
    private static void SeedMealTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MealType>().HasData(
            new MealType(id: 1, name: "Breakfast"),
            new MealType(id: 2, name: "Lunch"),
            new MealType(id: 3, name: "Dinner"),
            new MealType(id: 4, name: "Snack")
        );
    }
    
    private static void SeedDietaryOptions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DietaryOption>().HasData(
            new DietaryOption(id: 1, name: "Vegetarian", description: "Vegetarian option"),
            new DietaryOption(id: 2, name: "Vegan", description: "Vegan option"),
            new DietaryOption(id: 3, name: "Gluten-Free", description: "Gluten-Free option"),
            new DietaryOption(id: 4, name: "Dairy-Free", description: "Dairy-Free option")
        );
    }
    
    private static void SeedDifficultyOptions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DifficultyOption>().HasData(
            new DifficultyOption(id: 1, name: "Easy"),
            new DifficultyOption(id: 2, name: "Medium"),
            new DifficultyOption(id: 3, name: "Hard")
        );
    }
}