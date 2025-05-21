using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSRP.Application.DTOs.CuisineOptionDto;
using MSRP.Application.Queries.CuisineOptions.GetCuisineOptions;

namespace MSRP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CuisineOptionsController(IMediator mediator) : ControllerBase
{
    [HttpGet("GetCuisineOptions")]
    public async Task<ActionResult<IEnumerable<CuisineOptionDto>>> GetCuisineOptions()
    {
        var options = await mediator.Send(new GetCuisineOptionsQuery());
        if (options == null)
            return NotFound();
        
        return Ok(options);
    }
}