using MediatR;
using MSRP.Application.DTOs.DietaryOptionDto;
using MSRP.Application.Interfaces.DietaryOptionRepository;

namespace MSRP.Application.Queries.DietaryOptions.GetDietaryOptions;

public class GetDietaryOptionsQueryHandler(IDietaryOptionRepository repository)
    : IRequestHandler<GetDietaryOptionsQuery, List<DietaryOptionDto>?>
{
    public async Task<List<DietaryOptionDto>?> Handle(GetDietaryOptionsQuery request, CancellationToken cancellationToken)
    {
        var dietaryOptions = await repository.GetDietaryOptionsAsync(cancellationToken);
        
        return dietaryOptions?.Select(DietaryOptionDto.FromDietaryOption).ToList();
    }
}