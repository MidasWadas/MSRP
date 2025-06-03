using MSRP.Domain.MealType;

namespace MSRP.Application.Features.MealTypes.Interface;

public interface IMealTypesRepository
{
    Task<List<MealType>> GetMealTypesAsync(CancellationToken cancellationToken);
}