using MSRP.Application.Features.MealTypes.DTO;

namespace MSRP.Application.Features.MealTypes.Queries.GetMealTypes.Response;

public sealed record GetMealTypesResponse(List<MealTypeDto>? MealTypes);