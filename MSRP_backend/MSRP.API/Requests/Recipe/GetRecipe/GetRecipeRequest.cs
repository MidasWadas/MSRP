using System.ComponentModel.DataAnnotations;

namespace MSRP.API.Requests.Recipe.GetRecipe;

public class GetRecipeRequest
{
    [Required]
    public int Id { get; set; }
}