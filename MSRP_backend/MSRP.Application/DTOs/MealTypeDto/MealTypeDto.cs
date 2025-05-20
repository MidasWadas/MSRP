namespace MSRP.Application.DTOs.MealTypeDto;

public class MealTypeDto(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}