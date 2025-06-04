using MSRP.Domain.Difficulty;

namespace MSRP.Application.Features.Difficulties.Interface;

public interface IDifficultiesRepository
{
    Task<List<Difficulty>> GetDifficultyOptionsAsync(CancellationToken cancellationToken);
}