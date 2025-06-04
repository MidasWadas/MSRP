using System.ComponentModel.DataAnnotations;

namespace MSRP.API.Features.Recipe.Requests.GetRecipe;

public sealed record GetRecipeRequest([Required] int Id);