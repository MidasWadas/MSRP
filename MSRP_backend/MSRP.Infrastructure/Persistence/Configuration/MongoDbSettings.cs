namespace MSRP.Infrastructure.Persistence.MongoDB.Configuration;

public class MongoDbSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string RecipesCollectionName { get; set; }
    public string CuisineOptionsCollectionName { get; set; }
    public string DietaryOptionsCollectionName { get; set; }
    public string DifficultyOptionsCollectionName { get; set; }
    public string MealTypesCollectionName { get; set; }
}