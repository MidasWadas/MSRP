using MediatR;
using MSRP.Application.Features.Difficulties.DTO;
using MSRP.Application.Features.Difficulties.Interface;
using MSRP.Application.Features.Difficulties.Queries.GetDifficulties.Response;

namespace MSRP.Application.Features.Difficulties.Queries.GetDifficulties.Query;

public class GetDifficultiesQueryHandler(IDifficultiesRepository repository)
    : IRequestHandler<GetDifficultiesQuery, GetDifficultiesResponse>
{
    public async Task<GetDifficultiesResponse> Handle(GetDifficultiesQuery request, CancellationToken cancellationToken)
    {
        var difficultyOptions = await repository.GetDifficultyOptionsAsync(cancellationToken);
        
        return new GetDifficultiesResponse(difficultyOptions?.Select(DifficultyDto.FromDifficultyOption).ToList());
    }
}