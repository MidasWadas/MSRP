using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.DietaryOptionRepository;
using MSRP.Domain.Entities.DietaryOption;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class DietaryOptionRepository(ApiContext context) : IDietaryOptionRepository
{
    public async Task<List<DietaryOption>?> GetDietaryOptionsAsync(CancellationToken cancellationToken)
    {
        return await context.DietaryOptions
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}