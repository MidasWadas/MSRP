using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.Features.Dietaries.DTO;
using MSRP.Application.Features.Dietaries.Queries.GetDietaries;
using MSRP.Application.Features.Dietaries.Queries.GetDietaries.Query;
using MSRP.Application.Features.Dietaries.Queries.GetDietaries.Response;

namespace MSRP.API.Features.Dietary.Controller;

[Route("api/[controller]")]
[ApiController]
public class DietaryOptionsController(IMediator mediator) : ControllerBase
{
    [HttpGet("get-dietary-options")]
    [ProducesResponseType<GetDietariesResponse>(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetDietariesResponse>> GetDietaryOptions()
    {
        var options = await mediator.Send(new GetDietariesQuery());
        return Ok(options);
    }
}