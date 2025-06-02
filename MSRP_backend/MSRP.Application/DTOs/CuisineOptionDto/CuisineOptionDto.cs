using MSRP.Domain.Cuisine;

namespace MSRP.Application.DTOs.CuisineOptionDto;

public class CuisineOptionDto(int id, string name, string description)
{
    public int Id { get; init; } = id;
    public string Name { get; init; } = name;
    public string Description { get; init; } = description;
    
    public static CuisineOptionDto FromCuisineOption(Cuisine cuisine) =>
        new(cuisine.Id, cuisine.Name, cuisine.Description);
    
    public static Cuisine ToCuisineOption(CuisineOptionDto cuisineOptionDto) =>
        new(cuisineOptionDto.Id, cuisineOptionDto.Name, cuisineOptionDto.Description);
}