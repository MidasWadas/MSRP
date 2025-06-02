using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.DietaryOptionRepository;
using MSRP.Domain.Dietary;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class DietaryOptionRepository(ApiContext context) : IDietaryOptionRepository
{
    public async Task<List<Dietary>?> GetDietaryOptionsAsync(CancellationToken cancellationToken)
    {
        return await context.DietaryOptions
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}