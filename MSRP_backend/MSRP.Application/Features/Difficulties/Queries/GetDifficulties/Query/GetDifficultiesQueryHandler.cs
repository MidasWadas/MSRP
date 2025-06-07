using MediatR;
using MSRP.Application.Features.Difficulties.DTO;
using MSRP.Application.Features.Difficulties.Queries.GetDifficulties.Response;
using MSRP.Application.Interfaces.Repository;
using MSRP.Domain.Difficulty;

namespace MSRP.Application.Features.Difficulties.Queries.GetDifficulties.Query;

public class GetDifficultiesQueryHandler(IBaseRepository<Difficulty, DifficultyDto> repository)
    : IRequestHandler<GetDifficultiesQuery, GetDifficultiesResponse>
{
    public async Task<GetDifficultiesResponse> Handle(GetDifficultiesQuery request, CancellationToken cancellationToken)
    {
        var difficultyOptions = await repository.GetAllAsync(cancellationToken);
        
        return new GetDifficultiesResponse(difficultyOptions);
    }
}