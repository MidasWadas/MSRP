namespace MSRP.Infrastructure.Persistence.Configuration;

public sealed record MongoDbSettings
(
    string ConnectionString,
    string DatabaseName,
    string RecipesCollectionName,
    string CuisineOptionsCollectionName,
    string DietaryOptionsCollectionName,
    string DifficultyOptionsCollectionName,
    string MealTypesCollectionName
);