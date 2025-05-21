using MSRP.Domain.Entities.DietaryOption;

namespace MSRP.Application.Interfaces.DietaryOptionRepository;

public interface IDietaryOptionRepository
{
    Task<List<DietaryOption>?> GetDietaryOptionsAsync(CancellationToken cancellationToken);
}