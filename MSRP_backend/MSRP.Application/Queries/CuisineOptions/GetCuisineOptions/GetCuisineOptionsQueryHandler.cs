using MediatR;
using MSRP.Application.DTOs.CuisineOptionDto;
using MSRP.Application.Interfaces.CuisineOptionRepository;

namespace MSRP.Application.Queries.CuisineOptions.GetCuisineOptions;

public class GetCuisineOptionsQueryHandler(ICuisineOptionRepository repository)
    : IRequestHandler<GetCuisineOptionsQuery, List<CuisineOptionDto>?>
{
    public async Task<List<CuisineOptionDto>?> Handle(GetCuisineOptionsQuery request, CancellationToken cancellationToken)
    {
        var cuisineOptions = await repository.GetAllCuisineOptionsAsync(cancellationToken);
        
        return cuisineOptions.Select(CuisineOptionDto.FromCuisineOption).ToList();
    }
}