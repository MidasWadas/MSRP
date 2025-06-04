using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.Generator;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class Generator(ApiContext context) : IGenerator
{
    public async Task<int> GenerateNextIdAsync<T>(CancellationToken cancellationToken) where T : class
    {
        if (!context.Set<T>().Any())
            return 1;
        
        var maxId = await context.Set<T>()
            .Select(e => EF.Property<int>(e, "Id"))
            .DefaultIfEmpty(0)
            .MaxAsync(cancellationToken);
        
        return maxId + 1;
    }
}