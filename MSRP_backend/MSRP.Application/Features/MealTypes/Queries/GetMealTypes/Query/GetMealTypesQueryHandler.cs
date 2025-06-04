using MediatR;
using MSRP.Application.Features.MealTypes.DTO;
using MSRP.Application.Features.MealTypes.Interface;
using MSRP.Application.Features.MealTypes.Queries.GetMealTypes.Response;

namespace MSRP.Application.Features.MealTypes.Queries.GetMealTypes.Query;

public class GetMealTypesQueryHandler(IMealTypesRepository repository) 
    : IRequestHandler<GetMealTypesQuery, GetMealTypesResponse>
{
    public async Task<GetMealTypesResponse> Handle(GetMealTypesQuery request, CancellationToken cancellationToken)
    {
        var mealTypes = await repository.GetMealTypesAsync(cancellationToken);
        
        return new GetMealTypesResponse(mealTypes?.Select(MealTypeDto.FromMealType).ToList());
    }
}