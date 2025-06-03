using MediatR;
using MSRP.Application.Features.Dietaries.DTO;
using MSRP.Application.Features.Dietaries.Interface;
using MSRP.Application.Features.Dietaries.Queries.GetDietaries.Response;

namespace MSRP.Application.Features.Dietaries.Queries.GetDietaries.Query;

public class GetDietariesQueryHandler(IDietariesRepository repository)
    : IRequestHandler<GetDietariesQuery, GetDietariesResponse>
{
    public async Task<GetDietariesResponse> Handle(GetDietariesQuery request, CancellationToken cancellationToken)
    {
        var dietaryOptions = await repository.GetDietaryOptionsAsync(cancellationToken);
        
        return new GetDietariesResponse(dietaryOptions?.Select(DietaryDto.FromDietaryOption).ToList());
    }
}