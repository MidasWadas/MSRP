using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.DTOs.DifficultyOptionDto;
using MSRP.Application.Queries.DifficultyOptions.GetDifficultyOptions;

namespace MSRP.API.Difficulty.Controller;

[Route("api/[controller]")]
[ApiController]
public class DifficultyOptionsController(IMediator mediator) : ControllerBase
{
    [HttpGet("get-difficulty-options")]
    public async Task<ActionResult<IEnumerable<DifficultyOptionDto>>> GetDifficultyOptions()
    {
        var options = await mediator.Send(new GetDifficultyOptionsQuery());
        if (options == null)
            return NotFound();
        
        return Ok(options);
    }
}