using MediatR;
using MSRP.Application.Features.Difficulties.Queries.GetDifficulties.Response;

namespace MSRP.Application.Features.Difficulties.Queries.GetDifficulties.Query;

public sealed record GetDifficultiesQuery() : IRequest<GetDifficultiesResponse>;