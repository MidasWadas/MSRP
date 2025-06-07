using MediatR;
using MSRP.Application.Features.Cuisines.DTO;
using MSRP.Application.Features.Cuisines.Queries.GetCuisines.Response;
using MSRP.Application.Interfaces.Repository;
using MSRP.Domain.Cuisine;

namespace MSRP.Application.Features.Cuisines.Queries.GetCuisines.Query;

public class GetCuisinesQueryHandler(IBaseRepository<Cuisine, CuisineDto> repository)
    : IRequestHandler<GetCuisinesQuery, GetCuisinesResponse>
{
    public async Task<GetCuisinesResponse> Handle(GetCuisinesQuery request, CancellationToken cancellationToken)
    {
        var cuisineOptions = await repository.GetAllAsync(cancellationToken);
        
        return new GetCuisinesResponse(cuisineOptions);
    }
}