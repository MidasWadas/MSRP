using MSRP.Domain.Dietary;

namespace MSRP.Application.Features.Dietaries.DTO;

public sealed record DietaryDto(int Id, string Name, string Description)
{
    public static DietaryDto FromDietaryOption(Dietary dietary) =>
        new(dietary.Id, dietary.Name, dietary.Description);
    
    public static Dietary ToDietaryOption(DietaryDto dietaryDto) =>
        new(dietaryDto.Id, dietaryDto.Name, dietaryDto.Description);
}
