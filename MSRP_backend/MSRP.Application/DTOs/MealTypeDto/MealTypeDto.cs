using MSRP.Domain.Entities.MealType;

namespace MSRP.Application.DTOs.MealTypeDto;

public class MealTypeDto(int id, string name)
{
    public int Id { get; init; } = id;
    public string Name { get; init; } = name;
    
    public static MealTypeDto FromMealType(MealType mealType) =>
        new(mealType.Id, mealType.Name);
    
    public static MealType ToMealType(MealTypeDto mealTypeDto) =>
        new(mealTypeDto.Id, mealTypeDto.Name);
}