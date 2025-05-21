using MediatR;
using MSRP.Application.DTOs.DifficultyOptionDto;
using MSRP.Application.Interfaces.DifficultyOptionRepository;

namespace MSRP.Application.Queries.DifficultyOptions.GetDifficultyOptions;

public class GetDifficultyOptionsQueryHandler(IDifficultyOptionRepository repository)
    : IRequestHandler<GetDifficultyOptionsQuery, List<DifficultyOptionDto>?>
{
    public async Task<List<DifficultyOptionDto>?> Handle(GetDifficultyOptionsQuery request, CancellationToken cancellationToken)
    {
        var difficultyOptions = await repository.GetAllDifficultyOptionsAsync(cancellationToken);
        
        return difficultyOptions?.Select(DifficultyOptionDto.FromDifficultyOption).ToList();
    }
}