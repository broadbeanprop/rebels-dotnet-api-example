using Microsoft.AspNetCore.Mvc;
using Rebels.ExampleProject.Api.Dtos;
using Rebels.ExampleProject.Core.Services;

namespace Rebels.ExampleProject.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class RebelsController : ControllerBase
{
    private readonly ILogger<RebelsController> _logger;
    private readonly IRebelService _rebelService;

    public RebelsController(ILogger<RebelsController> logger, IRebelService rebelService)
    {
        _logger = logger;
        _rebelService = rebelService;
    }

    [HttpGet(Name = nameof(GetRebelsList))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RebelDto>))]
    public async Task<IActionResult> GetRebelsList(CancellationToken cancellationToken)
    {
        return Ok(await _rebelService.GetRebels(cancellationToken));
    }

    [HttpGet("{id:guid}", Name = nameof(GetRebelById))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RebelDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetRebelById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _rebelService.GetRebelById(id, cancellationToken);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost(Name = nameof(PostRebel))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IActionResult> PostRebel([FromBody] RebelDto rebel, CancellationToken cancellationToken)
    {
        var result =  await _rebelService.AddRebel(rebel, cancellationToken);
        return CreatedAtAction(nameof(GetRebelById), new { id = result.Id }, result);
    }
}