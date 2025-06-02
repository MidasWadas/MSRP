using MSRP.Domain.Dietary;

namespace MSRP.Application.DTOs.DietaryOptionDto;

public class DietaryOptionDto(int id, string name, string description)
{
    public int Id { get; init; } = id;
    public string Name { get; init; } = name;
    public string Description { get; init; } = description;
    
    public static DietaryOptionDto FromDietaryOption(Dietary dietary) =>
        new(dietary.Id, dietary.Name, dietary.Description);
    
    public static Dietary ToDietaryOption(DietaryOptionDto dietaryOptionDto) =>
        new(dietaryOptionDto.Id, dietaryOptionDto.Name, dietaryOptionDto.Description);
}
