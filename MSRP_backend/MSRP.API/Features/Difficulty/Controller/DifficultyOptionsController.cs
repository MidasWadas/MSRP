using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.Features.Difficulties.DTO;
using MSRP.Application.Features.Difficulties.Queries.GetDifficulties;
using MSRP.Application.Features.Difficulties.Queries.GetDifficulties.Query;

namespace MSRP.API.Features.Difficulty.Controller;

[Route("api/[controller]")]
[ApiController]
public class DifficultyOptionsController(IMediator mediator) : ControllerBase
{
    [HttpGet("get-difficulty-options")]
    public async Task<ActionResult<IEnumerable<DifficultyDto>>> GetDifficultyOptions()
    {
        var options = await mediator.Send(new GetDifficultiesQuery());
        if (options == null)
            return NotFound();
        
        return Ok(options);
    }
}