using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.DTOs.DifficultyOptionDto;
using MSRP.Application.Queries.DifficultyOptions.GetDifficultyOptions;

namespace MSRP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DifficultyOptionsController(IMediator mediator) : ControllerBase
{
    [HttpGet("GetDifficultyOptions")]
    public async Task<ActionResult<IEnumerable<DifficultyOptionDto>>> GetDifficultyOptions()
    {
        var options = await mediator.Send(new GetDifficultyOptionsQuery());
        if (options == null)
            return NotFound();
        
        return Ok(options);
    }
}