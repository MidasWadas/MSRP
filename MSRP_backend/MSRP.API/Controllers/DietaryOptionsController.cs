using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.DTOs.DietaryOptionDto;
using MSRP.Application.Queries.DietaryOptions.GetDietaryOptions;

namespace MSRP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DietaryOptionsController(IMediator mediator) : ControllerBase
{
    [HttpGet("GetDietaryOptions")]
    public async Task<ActionResult<IEnumerable<DietaryOptionDto>>> GetDietaryOptions()
    {
        var options = await mediator.Send(new GetDietaryOptionsQuery());
        if (options == null)
            return NotFound();
        
        return Ok(options);
    }
}