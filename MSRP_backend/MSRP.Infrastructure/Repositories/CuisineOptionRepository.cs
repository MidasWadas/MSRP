using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.CuisineOptionRepository;
using MSRP.Domain.Entities.CuisineOption;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class CuisineOptionRepository(ApiContext context) : ICuisineOptionRepository
{
    public async Task<List<CuisineOption>> GetCuisineOptionsAsync(CancellationToken cancellationToken)
    {
        return await context.CuisineOptions
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}