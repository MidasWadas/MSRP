using MSRP.Domain.Difficulty;

namespace MSRP.Application.Features.Difficulties.DTO;

public sealed record DifficultyDto(int Id, string Name)
{
    public static DifficultyDto FromDifficultyOption(Difficulty difficulty) =>
        new (difficulty.Id, difficulty.Name);
    
    public static Difficulty ToDifficultyOption(DifficultyDto difficultyDto) =>
        new (difficultyDto.Id, difficultyDto.Name);
}