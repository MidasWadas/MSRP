using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.Features.Cuisines.DTO;
using MSRP.Application.Features.Cuisines.Queries.GetCuisines;
using MSRP.Application.Features.Cuisines.Queries.GetCuisines.Query;

namespace MSRP.API.Features.Cuisine.Controller;

[Route("api/[controller]")]
[ApiController]
public class CuisineOptionsController(IMediator mediator) : ControllerBase
{
    [HttpGet("get-cuisine-options")]
    public async Task<ActionResult<IEnumerable<CuisineDto>>> GetCuisineOptions()
    {
        var options = await mediator.Send(new GetCuisinesQuery());
        if (options == null)
            return NotFound();
        
        return Ok(options);
    }
}