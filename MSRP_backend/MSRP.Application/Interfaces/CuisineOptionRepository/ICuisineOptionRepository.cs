using MSRP.Domain.Cuisine;

namespace MSRP.Application.Interfaces.CuisineOptionRepository;

public interface ICuisineOptionRepository
{
    Task<List<Cuisine>> GetCuisineOptionsAsync(CancellationToken cancellationToken);
}