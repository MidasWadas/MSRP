using MSRP.Domain.Entities.CuisineOption;

namespace MSRP.Application.DTOs.CuisineOptionDto;

public class CuisineOptionDto(int id, string name, string description)
{
    public int Id { get; init; } = id;
    public string Name { get; init; } = name;
    public string Description { get; init; } = description;
    
    public static CuisineOptionDto FromCuisineOption(CuisineOption cuisineOption) =>
        new(cuisineOption.Id, cuisineOption.Name, cuisineOption.Description);
    
    public static CuisineOption ToCuisineOption(CuisineOptionDto cuisineOptionDto) =>
        new(cuisineOptionDto.Id, cuisineOptionDto.Name, cuisineOptionDto.Description);
}