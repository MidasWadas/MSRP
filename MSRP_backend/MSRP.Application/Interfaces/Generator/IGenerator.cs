namespace MSRP.Application.Interfaces.Generator;

public interface IGenerator
{
    Task<int> GenerateNextIdAsync<T>(CancellationToken cancellationToken) where T : class;
}