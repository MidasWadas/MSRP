using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.DifficultyOptionRepository;
using MSRP.Domain.Entities.DifficultyOption;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class DifficultyOptionRepository(ApiContext context) : IDifficultyOptionRepository
{
    public async Task<List<DifficultyOption>> GetDifficultyOptionsAsync(CancellationToken cancellationToken)
    {
        return await context.DifficultyOptions
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}