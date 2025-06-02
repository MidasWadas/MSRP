using MSRP.Domain.Dietary;

namespace MSRP.Application.Interfaces.DietaryOptionRepository;

public interface IDietaryOptionRepository
{
    Task<List<Dietary>?> GetDietaryOptionsAsync(CancellationToken cancellationToken);
}