using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.Mapper;
using MSRP.Application.Interfaces.Repository;
using MSRP.Infrastructure.Mapper;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class BaseRepository<TEntity, TDto>(
        ApiContext context, 
        IEntityMapper entityMapper
    ) : IBaseRepository<TEntity, TDto> 
    where TEntity : class 
    where TDto : class
{
    protected virtual Task<TDto> ToDtoAsync(TEntity? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return entityMapper.MapToDtoAsync<TEntity, TDto>(entity);
    }
    
    protected virtual Task<List<TDto>> ToDtoListAsync(IEnumerable<TEntity> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);
        return Task.WhenAll(entities.Select(entityMapper.MapToDtoAsync<TEntity, TDto>)).ContinueWith(t => t.Result.ToList());
    }
    
    public async Task<List<TDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ToDtoListAsync(await context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(cancellationToken));
    }

    public async Task<TDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ToDtoAsync(await context.Set<TEntity>()
            .FindAsync([id], cancellationToken));
    }

    public async Task<TDto> CreateAsync(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();
        return await ToDtoAsync(entity);
    }

    [SuppressMessage("ReSharper", "EntityFramework.ClientSideDbFunctionCall")]
    public async Task<TDto> UpdateAsync(int id, TEntity entity)
    {
        if (!await context.Set<TEntity>().AsNoTracking().AnyAsync(e => EF.Property<int>(e, "Id") == id))
            throw new KeyNotFoundException($"Entity with ID {id} not found");

        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();
        return await ToDtoAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await context.Set<TEntity>().FindAsync(new object[] { id });
        if (entity == null)
            return false;

        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}
