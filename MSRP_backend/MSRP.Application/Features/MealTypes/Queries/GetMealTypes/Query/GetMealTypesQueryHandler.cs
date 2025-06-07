using MediatR;
using MSRP.Application.Features.MealTypes.DTO;
using MSRP.Application.Features.MealTypes.Queries.GetMealTypes.Response;
using MSRP.Application.Interfaces.Repository;
using MSRP.Domain.MealType;

namespace MSRP.Application.Features.MealTypes.Queries.GetMealTypes.Query;

public class GetMealTypesQueryHandler(IBaseRepository<MealType, MealTypeDto> repository) 
    : IRequestHandler<GetMealTypesQuery, GetMealTypesResponse>
{
    public async Task<GetMealTypesResponse> Handle(GetMealTypesQuery request, CancellationToken cancellationToken)
    {
        var mealTypes = await repository.GetAllAsync(cancellationToken);
        
        return new GetMealTypesResponse(mealTypes);
    }
}