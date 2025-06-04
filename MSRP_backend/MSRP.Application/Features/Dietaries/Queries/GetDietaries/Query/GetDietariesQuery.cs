using MediatR;
using MSRP.Application.Features.Dietaries.Queries.GetDietaries.Response;

namespace MSRP.Application.Features.Dietaries.Queries.GetDietaries.Query;

public sealed record GetDietariesQuery() : IRequest<GetDietariesResponse>;