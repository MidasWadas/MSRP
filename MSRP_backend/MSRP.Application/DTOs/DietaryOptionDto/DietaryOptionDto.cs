using MSRP.Domain.Entities.DietaryOption;

namespace MSRP.Application.DTOs.DietaryOptionDto;

public class DietaryOptionDto(int id, string name, string description)
{
    public int Id { get; init; } = id;
    public string Name { get; init; } = name;
    public string Description { get; init; } = description;
    
    public static DietaryOptionDto FromDietaryOption(DietaryOption dietaryOption) =>
        new(dietaryOption.Id, dietaryOption.Name, dietaryOption.Description);
    
    public static DietaryOption ToDietaryOption(DietaryOptionDto dietaryOptionDto) =>
        new(dietaryOptionDto.Id, dietaryOptionDto.Name, dietaryOptionDto.Description);
}
