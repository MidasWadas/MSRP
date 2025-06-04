using MSRP.Domain.Cuisine;

namespace MSRP.Application.Features.Cuisines.Interface;

public interface ICuisinesRepository
{
    Task<List<Cuisine>> GetCuisineOptionsAsync(CancellationToken cancellationToken);
}