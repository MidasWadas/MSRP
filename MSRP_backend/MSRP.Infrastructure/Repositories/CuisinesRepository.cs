using Microsoft.EntityFrameworkCore;
using MSRP.Application.Features.Cuisines.Interface;
using MSRP.Domain.Cuisine;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class CuisinesRepository(ApiContext context) : ICuisinesRepository
{
    public async Task<List<Cuisine>> GetCuisineOptionsAsync(CancellationToken cancellationToken)
    {
        return await context.Cuisines
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}