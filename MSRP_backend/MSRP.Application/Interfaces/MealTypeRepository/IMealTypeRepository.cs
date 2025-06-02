using MSRP.Domain.MealType;

namespace MSRP.Application.Interfaces.MealTypeRepository;

public interface IMealTypeRepository
{
    Task<List<MealType>> GetMealTypesAsync(CancellationToken cancellationToken);
}