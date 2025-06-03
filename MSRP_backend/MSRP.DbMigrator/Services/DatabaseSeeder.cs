using Microsoft.EntityFrameworkCore;
using MSRP.Domain.Cuisine;
using MSRP.Domain.Dietary;
using MSRP.Domain.Difficulty;
using MSRP.Domain.MealType;
using MSRP.Infrastructure.Persistence;

namespace MSRP.DbMigrator.Services;

public class DatabaseSeeder(ApiContext context)
{
    public async Task SeedAsync()
    {
        Console.WriteLine("Initializing data...");

        if (!await context.Cuisines.AnyAsync())
            await SeedCuisineOptionsAsync();

        if (!await context.MealTypes.AnyAsync())
            await SeedMealTypesAsync();

        if (!await context.Dietaries.AnyAsync())
            await SeedDietaryOptionsAsync();

        if (!await context.Difficulties.AnyAsync())
            await SeedDifficultyOptionsAsync();

        await context.SaveChangesAsync();
    }

    private async Task SeedCuisineOptionsAsync()
    {
        Console.WriteLine("Adding cuisine options...");
        await context.Cuisines.AddRangeAsync(
            new Cuisine(id: 1, name: "Italian", description: "Italian cuisine"),
            new Cuisine(id: 2, name: "Mexican", description: "Mexican cuisine"),
            new Cuisine(id: 3, name: "Japanese", description: "Japanese cuisine"),
            new Cuisine(id: 4, name: "Indian", description: "Indian cuisine"),
            new Cuisine(id: 5, name: "Mediterranean", description: "Mediterranean cuisine")
        );
    }

    private async Task SeedMealTypesAsync()
    {
        Console.WriteLine("Adding meal types...");
        await context.MealTypes.AddRangeAsync(
            new MealType(id: 1, name: "Breakfast"),
            new MealType(id: 2, name: "Lunch"),
            new MealType(id: 3, name: "Dinner"),
            new MealType(id: 4, name: "Snack")
        );
    }

    private async Task SeedDietaryOptionsAsync()
    {
        Console.WriteLine("Adding dietary options...");
        await context.Dietaries.AddRangeAsync(
            new Dietary(id: 1, name: "Vegetarian", description: "Vegetarian option"),
            new Dietary(id: 2, name: "Vegan", description: "Vegan option"),
            new Dietary(id: 3, name: "Gluten-Free", description: "Gluten-Free option"),
            new Dietary(id: 4, name: "Dairy-Free", description: "Dairy-Free option")
        );
    }

    private async Task SeedDifficultyOptionsAsync()
    {
        Console.WriteLine("Adding difficulty options...");
        await context.Difficulties.AddRangeAsync(
            new Difficulty(id: 1, name: "Easy"),
            new Difficulty(id: 2, name: "Medium"),
            new Difficulty(id: 3, name: "Hard")
        );
    }
}