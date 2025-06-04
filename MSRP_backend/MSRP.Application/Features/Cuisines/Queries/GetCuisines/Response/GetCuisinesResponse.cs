using MSRP.Application.Features.Cuisines.DTO;

namespace MSRP.Application.Features.Cuisines.Queries.GetCuisines.Response;

public sealed record GetCuisinesResponse(List<CuisineDto>? Cuisines);