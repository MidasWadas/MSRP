using MediatR;
using MSRP.Application.DTOs.CuisineOptionDto;

namespace MSRP.Application.Queries.CuisineOptions.GetCuisineOptions;

public sealed record GetCuisineOptionsQuery() : IRequest<List<CuisineOptionDto>?>;