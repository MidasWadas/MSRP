using MSRP.Domain.Difficulty;

namespace MSRP.Application.DTOs.DifficultyOptionDto;

public class DifficultyOptionDto(int id, string name)
{
    public int Id { get; init; } = id;
    public string Name { get; init; } = name;
    
    public static DifficultyOptionDto FromDifficultyOption(Difficulty difficulty) =>
        new (difficulty.Id, difficulty.Name);
    
    public static Difficulty ToDifficultyOption(DifficultyOptionDto difficultyOptionDto) =>
        new (difficultyOptionDto.Id, difficultyOptionDto.Name);
}