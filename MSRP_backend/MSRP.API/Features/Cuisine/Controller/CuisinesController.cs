using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.Features.Cuisines.Queries.GetCuisines.Query;
using MSRP.Application.Features.Cuisines.Queries.GetCuisines.Response;

namespace MSRP.API.Features.Cuisine.Controller;

[Route("api/[controller]")]
[ApiController]
public class CuisinesController(IMediator mediator) : ControllerBase
{
    [HttpGet("get-all")]
    [ProducesResponseType<GetCuisinesResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetCuisinesResponse>> GetAll()
    {
        var options = await mediator.Send(new GetCuisinesQuery());
        return Ok(options);
    }
}