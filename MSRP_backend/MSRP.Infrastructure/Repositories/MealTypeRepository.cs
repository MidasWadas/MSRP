using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.MealTypeRepository;
using MSRP.Domain.Entities.MealType;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class MealTypeRepository(ApiContext context) : IMealTypeRepository
{
    public async Task<List<MealType>> GetMealTypesAsync(CancellationToken cancellationToken)
    {
        return await context.MealTypes
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}