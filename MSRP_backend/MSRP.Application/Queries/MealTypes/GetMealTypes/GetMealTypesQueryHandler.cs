using MediatR;
using MSRP.Application.DTOs.MealTypeDto;
using MSRP.Application.Interfaces.MealTypeRepository;

namespace MSRP.Application.Queries.MealTypes.GetMealTypes;

public class GetMealTypesQueryHandler(IMealTypeRepository repository) 
    : IRequestHandler<GetMealTypesQuery, List<MealTypeDto>?>
{
    public async Task<List<MealTypeDto>?> Handle(GetMealTypesQuery request, CancellationToken cancellationToken)
    {
        var mealTypes = await repository.GetAllMealTypesAsync(cancellationToken);
        
        return mealTypes?.Select(MealTypeDto.FromMealType).ToList();
    }
}