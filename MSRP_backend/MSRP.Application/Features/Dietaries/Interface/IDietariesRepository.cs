using MSRP.Domain.Dietary;

namespace MSRP.Application.Features.Dietaries.Interface;

public interface IDietariesRepository
{
    Task<List<Dietary>?> GetDietaryOptionsAsync(CancellationToken cancellationToken);
}