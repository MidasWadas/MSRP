using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.DTOs.MealTypeDto;
using MSRP.Application.Queries.MealTypes.GetMealTypes;

namespace MSRP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MealTypesController(IMediator mediator) : ControllerBase
{
    [HttpGet("GetMealTypes")]
    public async Task<ActionResult<IEnumerable<MealTypeDto>>> GetMealTypes()
    {
        var mealTypes = await mediator.Send(new GetMealTypesQuery());
        if (mealTypes == null)
            return NotFound();
        
        return Ok(mealTypes);
    }
}