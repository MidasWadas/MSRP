using MediatR;
using MSRP.Application.Features.Cuisines.Queries.GetCuisines.Response;

namespace MSRP.Application.Features.Cuisines.Queries.GetCuisines.Query;

public sealed record GetCuisinesQuery() : IRequest<GetCuisinesResponse>;