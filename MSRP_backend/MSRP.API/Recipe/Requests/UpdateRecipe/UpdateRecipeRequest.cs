namespace MSRP.API.Recipe.Requests.UpdateRecipe;

public class UpdateRecipeRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public int Servings { get; set; }
    public int DifficultyId { get; set; }
    public int CuisineId { get; set; }
    public int MealTypeId { get; set; }
    public List<int> DietariesIds { get; set; }
    public List<string> Ingredients { get; set; }
    public List<string> Instruction { get; set; }
    public int UpdatedByUserId { get; set; }
}
