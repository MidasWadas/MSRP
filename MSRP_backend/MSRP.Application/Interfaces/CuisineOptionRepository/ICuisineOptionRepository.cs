using MSRP.Domain.Entities.CuisineOption;

namespace MSRP.Application.Interfaces.CuisineOptionRepository;

public interface ICuisineOptionRepository
{
    Task<List<CuisineOption>> GetCuisineOptionsAsync(CancellationToken cancellationToken);
}