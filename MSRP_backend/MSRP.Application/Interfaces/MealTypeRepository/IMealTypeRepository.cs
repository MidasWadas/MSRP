using MSRP.Domain.Entities.MealType;

namespace MSRP.Application.Interfaces.MealTypeRepository;

public interface IMealTypeRepository
{
    Task<List<MealType>> GetAllMealTypesAsync(CancellationToken cancellationToken);
}