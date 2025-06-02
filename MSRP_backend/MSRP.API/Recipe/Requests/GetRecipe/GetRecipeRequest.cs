using System.ComponentModel.DataAnnotations;

namespace MSRP.API.Recipe.Requests.GetRecipe;

public class GetRecipeRequest
{
    [Required]
    public int Id { get; set; }
}