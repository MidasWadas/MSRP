using MSRP.Application.Features.Cuisines.DTO;
using MSRP.Application.Features.Dietaries.DTO;
using MSRP.Application.Features.Difficulties.DTO;
using MSRP.Application.Features.MealTypes.DTO;
using MSRP.Application.Interfaces.Mapper;
using MSRP.Domain.Cuisine;
using MSRP.Domain.Dietary;
using MSRP.Domain.Difficulty;
using MSRP.Domain.MealType;

namespace MSRP.Infrastructure.Mapper;

public class EntityMapper : IEntityMapper
{
    public Task<TDto> MapToDtoAsync<TEntity, TDto>(TEntity entity) where TEntity : class where TDto : class
    {
        ArgumentNullException.ThrowIfNull(entity);

        object dto = entity switch
        {
            MealType mealType when typeof(TDto) == typeof(MealTypeDto) => MapToDto(mealType),
            Difficulty difficulty when typeof(TDto) == typeof(DifficultyDto) => MapToDto(difficulty),
            Cuisine cuisine when typeof(TDto) == typeof(CuisineDto) => MapToDto(cuisine),
            Dietary dietary when typeof(TDto) == typeof(DietaryDto) => MapToDto(dietary),
            _ => throw new NotSupportedException($"Mapping for {typeof(TEntity).Name} to {typeof(TDto).Name} is not supported.")
        };

        return Task.FromResult((TDto)dto);
    }
    
    private static MealTypeDto MapToDto(MealType mealType) => new MealTypeDto(mealType.Id, mealType.Name);
    
    private static DifficultyDto MapToDto(Difficulty difficulty) => new DifficultyDto(difficulty.Id, difficulty.Name);
    
    private static CuisineDto MapToDto(Cuisine cuisine) => new CuisineDto(cuisine.Id, cuisine.Name, cuisine.Description);
    
    private static DietaryDto MapToDto(Dietary dietary) => new DietaryDto(dietary.Id, dietary.Name, dietary.Description);
}