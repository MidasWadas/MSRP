using MSRP.Domain.Entities.DifficultyOption;

namespace MSRP.Application.DTOs.DifficultyOptionDto;

public class DifficultyOptionDto(int id, string name)
{
    public int Id { get; init; } = id;
    public string Name { get; init; } = name;
    
    public static DifficultyOptionDto FromDifficultyOption(DifficultyOption difficultyOption) =>
        new (difficultyOption.Id, difficultyOption.Name);
    
    public static DifficultyOption ToDifficultyOption(DifficultyOptionDto difficultyOptionDto) =>
        new (difficultyOptionDto.Id, difficultyOptionDto.Name);
}