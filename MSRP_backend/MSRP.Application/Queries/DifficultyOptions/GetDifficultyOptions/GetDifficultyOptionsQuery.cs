using MediatR;
using MSRP.Application.DTOs.DifficultyOptionDto;

namespace MSRP.Application.Queries.DifficultyOptions.GetDifficultyOptions;

public sealed record GetDifficultyOptionsQuery() : IRequest<List<DifficultyOptionDto>?>;