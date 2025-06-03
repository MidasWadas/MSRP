namespace MSRP.Application.Interfaces.Repository;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(int id, T entity);
    Task<bool> DeleteAsync(int id);
}