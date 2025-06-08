using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.Features.Difficulties.Queries.GetDifficulties.Query;
using MSRP.Application.Features.Difficulties.Queries.GetDifficulties.Response;

namespace MSRP.API.Features.Difficulty.Controller;

[Route("api/[controller]")]
[ApiController]
public class DifficultiesController(IMediator mediator) : ControllerBase
{
    [HttpGet("get-all")]
    [ProducesResponseType<GetDifficultiesResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetDifficultiesResponse>> GetAll()
    {
        var options = await mediator.Send(new GetDifficultiesQuery());
        return Ok(options);
    }
}