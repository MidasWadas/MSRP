using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.Repository;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class BaseRepository<T>(ApiContext context) : IBaseRepository<T> where T : class
{
    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Set<T>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Set<T>()
            .FindAsync([id], cancellationToken);
    }

    public async Task<T> CreateAsync(T entity)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    [SuppressMessage("ReSharper", "EntityFramework.ClientSideDbFunctionCall")]
    public async Task<T> UpdateAsync(int id, T entity)
    {
        if (!await context.Set<T>().AsNoTracking().AnyAsync(e => EF.Property<int>(e, "Id") == id))
            throw new KeyNotFoundException($"Entity with ID {id} not found");

        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await context.Set<T>().FindAsync(new object[] { id });
        if (entity == null)
            return false;

        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}
