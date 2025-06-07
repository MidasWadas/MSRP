namespace MSRP.Application.Interfaces.Repository;

public interface IBaseRepository<in TEntity, TDto> where TEntity : class
{
    Task<List<TDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TDto> CreateAsync(TEntity entity);
    Task<TDto> UpdateAsync(int id, TEntity entity);
    Task<bool> DeleteAsync(int id);
}