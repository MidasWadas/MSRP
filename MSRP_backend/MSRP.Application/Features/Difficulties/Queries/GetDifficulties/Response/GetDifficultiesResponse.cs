using MSRP.Application.Features.Difficulties.DTO;

namespace MSRP.Application.Features.Difficulties.Queries.GetDifficulties.Response;

public sealed record GetDifficultiesResponse(List<DifficultyDto>? Difficulties);