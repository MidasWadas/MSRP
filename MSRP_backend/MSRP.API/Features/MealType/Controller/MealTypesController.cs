using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.Features.MealTypes.Queries.GetMealTypes.Query;
using MSRP.Application.Features.MealTypes.Queries.GetMealTypes.Response;

namespace MSRP.API.Features.MealType.Controller;

[Route("api/[controller]")]
[ApiController]
public class MealTypesController(IMediator mediator) : ControllerBase
{
    [HttpGet("get-all")]
    [ProducesResponseType<GetMealTypesResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetMealTypesResponse>> GetAll()
    {
        var mealTypes = await mediator.Send(new GetMealTypesQuery());
        return Ok(mealTypes);
    }
}