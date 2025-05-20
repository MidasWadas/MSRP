namespace MSRP.Application.DTOs.DifficultyOptionDto;

public class DifficultyOptionDto(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}