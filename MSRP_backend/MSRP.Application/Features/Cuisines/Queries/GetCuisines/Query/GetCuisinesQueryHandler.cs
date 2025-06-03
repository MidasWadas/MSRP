using MediatR;
using MSRP.Application.Features.Cuisines.DTO;
using MSRP.Application.Features.Cuisines.Interface;
using MSRP.Application.Features.Cuisines.Queries.GetCuisines.Response;

namespace MSRP.Application.Features.Cuisines.Queries.GetCuisines.Query;

public class GetCuisinesQueryHandler(ICuisinesRepository repository)
    : IRequestHandler<GetCuisinesQuery, GetCuisinesResponse>
{
    public async Task<GetCuisinesResponse> Handle(GetCuisinesQuery request, CancellationToken cancellationToken)
    {
        var cuisineOptions = await repository.GetCuisineOptionsAsync(cancellationToken);
        
        return new GetCuisinesResponse(cuisineOptions.Select(CuisineDto.FromCuisineOption).ToList());
    }
}