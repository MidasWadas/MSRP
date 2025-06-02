using MSRP.Domain.Difficulty;

namespace MSRP.Application.Interfaces.DifficultyOptionRepository;

public interface IDifficultyOptionRepository
{
    Task<List<Difficulty>> GetDifficultyOptionsAsync(CancellationToken cancellationToken);
}