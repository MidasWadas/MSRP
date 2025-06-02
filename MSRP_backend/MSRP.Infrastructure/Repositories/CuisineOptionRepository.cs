using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.CuisineOptionRepository;
using MSRP.Domain.Cuisine;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class CuisineOptionRepository(ApiContext context) : ICuisineOptionRepository
{
    public async Task<List<Cuisine>> GetCuisineOptionsAsync(CancellationToken cancellationToken)
    {
        return await context.CuisineOptions
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}