using MSRP.Domain.MealType;

namespace MSRP.Application.Features.MealTypes.DTO;

public sealed record MealTypeDto(int Id, string Name)
{
    public static MealTypeDto FromMealType(MealType mealType) =>
        new(mealType.Id, mealType.Name);
    
    public static MealType ToMealType(MealTypeDto mealTypeDto) =>
        new(mealTypeDto.Id, mealTypeDto.Name);
}