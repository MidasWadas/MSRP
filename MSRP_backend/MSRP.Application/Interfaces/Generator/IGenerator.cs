namespace MSRP.Application.Interfaces.Generator;

public interface IGenerator
{
    Task<int> GenerateNextRecipeIdAsync(CancellationToken cancellationToken);
    Task<int> GenerateNextMealTypeIdAsync(CancellationToken cancellationToken);
    Task<int> GenerateNextDietaryOptionIdAsync(CancellationToken cancellationToken);
    Task<int> GenerateNextCuisineOptionIdAsync(CancellationToken cancellationToken);
    Task<int> GenerateNextDifficultyOptionIdAsync(CancellationToken cancellationToken);
}