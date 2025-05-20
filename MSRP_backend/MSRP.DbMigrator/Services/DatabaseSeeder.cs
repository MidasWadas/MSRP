using Microsoft.EntityFrameworkCore;
using MSRP.Domain.Entities.CuisineOption;
using MSRP.Domain.Entities.DietaryOption;
using MSRP.Domain.Entities.DifficultyOption;
using MSRP.Domain.Entities.MealType;
using MSRP.Infrastructure.Persistence;

namespace MSRP.DbMigrator.Services;

public class DatabaseSeeder(ApiContext context)
{
    public async Task SeedAsync()
    {
        Console.WriteLine("Initializing data...");

        if (!await context.CuisineOptions.AnyAsync())
            await SeedCuisineOptionsAsync();

        if (!await context.MealTypeOptions.AnyAsync())
            await SeedMealTypesAsync();

        if (!await context.DietaryOptions.AnyAsync())
            await SeedDietaryOptionsAsync();

        if (!await context.DifficultyOptions.AnyAsync())
            await SeedDifficultyOptionsAsync();

        await context.SaveChangesAsync();
    }

    private async Task SeedCuisineOptionsAsync()
    {
        Console.WriteLine("Adding cuisine options...");
        await context.CuisineOptions.AddRangeAsync(
            new CuisineOption(id: 1, name: "Italian", description: "Italian cuisine"),
            new CuisineOption(id: 2, name: "Mexican", description: "Mexican cuisine"),
            new CuisineOption(id: 3, name: "Japanese", description: "Japanese cuisine"),
            new CuisineOption(id: 4, name: "Indian", description: "Indian cuisine"),
            new CuisineOption(id: 5, name: "Mediterranean", description: "Mediterranean cuisine")
        );
    }

    private async Task SeedMealTypesAsync()
    {
        Console.WriteLine("Adding meal types...");
        await context.MealTypeOptions.AddRangeAsync(
            new MealType(id: 1, name: "Breakfast"),
            new MealType(id: 2, name: "Lunch"),
            new MealType(id: 3, name: "Dinner"),
            new MealType(id: 4, name: "Snack")
        );
    }

    private async Task SeedDietaryOptionsAsync()
    {
        Console.WriteLine("Adding dietary options...");
        await context.DietaryOptions.AddRangeAsync(
            new DietaryOption(id: 1, name: "Vegetarian", description: "Vegetarian option"),
            new DietaryOption(id: 2, name: "Vegan", description: "Vegan option"),
            new DietaryOption(id: 3, name: "Gluten-Free", description: "Gluten-Free option"),
            new DietaryOption(id: 4, name: "Dairy-Free", description: "Dairy-Free option")
        );
    }

    private async Task SeedDifficultyOptionsAsync()
    {
        Console.WriteLine("Adding difficulty options...");
        await context.DifficultyOptions.AddRangeAsync(
            new DifficultyOption(id: 1, name: "Easy"),
            new DifficultyOption(id: 2, name: "Medium"),
            new DifficultyOption(id: 3, name: "Hard")
        );
    }
}