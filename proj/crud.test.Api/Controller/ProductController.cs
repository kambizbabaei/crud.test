using crud.test.Abstraction.Commands;
using crud.test.Abstraction.Queries;
using crud.test.Application.Commands;
using crud.test.Application.Dtoes;
using crud.test.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace crud.test.Api.Controller;

public class ProductController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ProductController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] GetProductByIdQuery query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> Get([FromQuery] SearchProductByNameQuery query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }


    [HttpPut("{ProductId}/")]
    public async Task<IActionResult> Put([FromBody] UpdateProductCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpDelete("{ProductId:guid}")]
    public async Task<IActionResult> Delete([FromBody] RemoveProductCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpPost()]
    public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
}