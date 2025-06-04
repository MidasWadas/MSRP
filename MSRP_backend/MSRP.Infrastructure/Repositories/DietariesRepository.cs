using Microsoft.EntityFrameworkCore;
using MSRP.Application.Features.Dietaries.Interface;
using MSRP.Domain.Dietary;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class DietariesRepository(ApiContext context) : IDietariesRepository
{
    public async Task<List<Dietary>?> GetDietaryOptionsAsync(CancellationToken cancellationToken)
    {
        return await context.Dietaries
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}