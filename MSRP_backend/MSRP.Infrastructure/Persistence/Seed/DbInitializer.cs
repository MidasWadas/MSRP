using Microsoft.EntityFrameworkCore;
using MSRP.Domain.Cuisine;
using MSRP.Domain.Dietary;
using MSRP.Domain.Difficulty;
using MSRP.Domain.MealType;

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
        modelBuilder.Entity<Cuisine>().HasData(
            new Cuisine(id: 1, name: "Italian", description: "Italian cuisine"),
            new Cuisine(id: 2, name: "Mexican", description: "Mexican cuisine"),
            new Cuisine(id: 3, name: "Japanese", description: "Japanese cuisine"),
            new Cuisine(id: 4, name: "Indian", description: "Indian cuisine"),
            new Cuisine(id: 5, name: "Mediterranean", description: "Mediterranean cuisine")
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
        modelBuilder.Entity<Dietary>().HasData(
            new Dietary(id: 1, name: "Vegetarian", description: "Vegetarian option"),
            new Dietary(id: 2, name: "Vegan", description: "Vegan option"),
            new Dietary(id: 3, name: "Gluten-Free", description: "Gluten-Free option"),
            new Dietary(id: 4, name: "Dairy-Free", description: "Dairy-Free option")
        );
    }
    
    private static void SeedDifficultyOptions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Difficulty>().HasData(
            new Difficulty(id: 1, name: "Easy"),
            new Difficulty(id: 2, name: "Medium"),
            new Difficulty(id: 3, name: "Hard")
        );
    }
}