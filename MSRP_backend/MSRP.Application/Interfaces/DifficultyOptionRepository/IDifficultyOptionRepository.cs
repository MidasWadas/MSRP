using MSRP.Domain.Entities.DifficultyOption;

namespace MSRP.Application.Interfaces.DifficultyOptionRepository;

public interface IDifficultyOptionRepository
{
    Task<List<DifficultyOption>> GetDifficultyOptionsAsync(CancellationToken cancellationToken);
}