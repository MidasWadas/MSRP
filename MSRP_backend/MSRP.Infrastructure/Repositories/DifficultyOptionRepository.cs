using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.DifficultyOptionRepository;
using MSRP.Domain.Difficulty;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class DifficultyOptionRepository(ApiContext context) : IDifficultyOptionRepository
{
    public async Task<List<Difficulty>> GetDifficultyOptionsAsync(CancellationToken cancellationToken)
    {
        return await context.DifficultyOptions
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}