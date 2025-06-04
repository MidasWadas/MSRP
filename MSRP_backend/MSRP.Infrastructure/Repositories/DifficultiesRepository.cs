using Microsoft.EntityFrameworkCore;
using MSRP.Application.Features.Difficulties.Interface;
using MSRP.Domain.Difficulty;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class DifficultiesRepository(ApiContext context) : IDifficultiesRepository
{
    public async Task<List<Difficulty>> GetDifficultyOptionsAsync(CancellationToken cancellationToken)
    {
        return await context.Difficulties
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}