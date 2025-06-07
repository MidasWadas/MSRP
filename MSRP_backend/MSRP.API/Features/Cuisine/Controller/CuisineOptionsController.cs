using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.Features.Cuisines.DTO;
using MSRP.Application.Features.Cuisines.Queries.GetCuisines;
using MSRP.Application.Features.Cuisines.Queries.GetCuisines.Query;
using MSRP.Application.Features.Cuisines.Queries.GetCuisines.Response;

namespace MSRP.API.Features.Cuisine.Controller;

[Route("api/[controller]")]
[ApiController]
public class CuisineOptionsController(IMediator mediator) : ControllerBase
{
    [HttpGet("get-cuisine-options")]
    [ProducesResponseType<GetCuisinesResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetCuisinesResponse>> GetCuisineOptions()
    {
        var options = await mediator.Send(new GetCuisinesQuery());
        return Ok(options);
    }
}