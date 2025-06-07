namespace MSRP.Application.Interfaces.Mapper;

public interface IEntityMapper
{
    Task<TDto> MapToDtoAsync<TEntity, TDto>(TEntity entity)
        where TEntity : class
        where TDto : class;
}