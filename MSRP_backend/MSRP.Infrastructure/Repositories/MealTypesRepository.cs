using Microsoft.EntityFrameworkCore;
using MSRP.Application.Features.MealTypes.Interface;
using MSRP.Domain.MealType;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class MealTypesRepository(ApiContext context) : IMealTypesRepository
{
    public async Task<List<MealType>> GetMealTypesAsync(CancellationToken cancellationToken)
    {
        return await context.MealTypes
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}