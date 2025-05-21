using MediatR;
using MSRP.Application.DTOs.MealTypeDto;

namespace MSRP.Application.Queries.MealTypes.GetMealTypes;

public sealed record GetMealTypesQuery() : IRequest<List<MealTypeDto>?>;