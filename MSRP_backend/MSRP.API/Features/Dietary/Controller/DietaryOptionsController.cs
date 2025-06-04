using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.Features.Dietaries.DTO;
using MSRP.Application.Features.Dietaries.Queries.GetDietaries;
using MSRP.Application.Features.Dietaries.Queries.GetDietaries.Query;

namespace MSRP.API.Features.Dietary.Controller;

[Route("api/[controller]")]
[ApiController]
public class DietaryOptionsController(IMediator mediator) : ControllerBase
{
    [HttpGet("get-dietary-options")]
    public async Task<ActionResult<IEnumerable<DietaryDto>>> GetDietaryOptions()
    {
        var options = await mediator.Send(new GetDietariesQuery());
        if (options == null)
            return NotFound();
        
        return Ok(options);
    }
}