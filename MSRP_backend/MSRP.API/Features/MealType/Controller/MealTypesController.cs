using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.Features.MealTypes.DTO;
using MSRP.Application.Features.MealTypes.Queries.GetMealTypes;
using MSRP.Application.Features.MealTypes.Queries.GetMealTypes.Query;
using MSRP.Application.Features.MealTypes.Queries.GetMealTypes.Response;

namespace MSRP.API.Features.MealType.Controller;

[Route("api/[controller]")]
[ApiController]
public class MealTypesController(IMediator mediator) : ControllerBase
{
    [HttpGet("get-meal-types")]
    [ProducesResponseType<GetMealTypesResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetMealTypesResponse>> GetMealTypes()
    {
        var mealTypes = await mediator.Send(new GetMealTypesQuery());
        return Ok(mealTypes);
    }
}