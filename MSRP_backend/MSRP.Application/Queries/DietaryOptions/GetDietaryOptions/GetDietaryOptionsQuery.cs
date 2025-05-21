using MediatR;
using MSRP.Application.DTOs.DietaryOptionDto;

namespace MSRP.Application.Queries.DietaryOptions.GetDietaryOptions;

public sealed record GetDietaryOptionsQuery() : IRequest<List<DietaryOptionDto>?>;