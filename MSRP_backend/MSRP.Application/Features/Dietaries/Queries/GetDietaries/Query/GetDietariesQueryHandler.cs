using MediatR;
using MSRP.Application.Features.Dietaries.DTO;
using MSRP.Application.Features.Dietaries.Queries.GetDietaries.Response;
using MSRP.Application.Interfaces.Repository;
using MSRP.Domain.Dietary;

namespace MSRP.Application.Features.Dietaries.Queries.GetDietaries.Query;

public class GetDietariesQueryHandler(IBaseRepository<Dietary, DietaryDto> repository)
    : IRequestHandler<GetDietariesQuery, GetDietariesResponse>
{
    public async Task<GetDietariesResponse> Handle(GetDietariesQuery request, CancellationToken cancellationToken)
    {
        var dietaryOptions = await repository.GetAllAsync(cancellationToken);
        
        return new GetDietariesResponse(dietaryOptions);
    }
}