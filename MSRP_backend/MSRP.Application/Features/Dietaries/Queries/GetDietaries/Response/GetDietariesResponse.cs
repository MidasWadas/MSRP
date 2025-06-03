using MSRP.Application.Features.Dietaries.DTO;

namespace MSRP.Application.Features.Dietaries.Queries.GetDietaries.Response;

public sealed record GetDietariesResponse(List<DietaryDto>? Dietaries);