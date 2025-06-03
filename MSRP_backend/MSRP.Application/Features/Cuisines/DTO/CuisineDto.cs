using MSRP.Domain.Cuisine;

namespace MSRP.Application.Features.Cuisines.DTO;

public sealed record CuisineDto(int Id, string Name, string Description)
{
    public static CuisineDto FromCuisineOption(Cuisine cuisine) =>
        new(cuisine.Id, cuisine.Name, cuisine.Description);
    
    public static Cuisine ToCuisineOption(CuisineDto cuisineDto) =>
        new(cuisineDto.Id, cuisineDto.Name, cuisineDto.Description);
}