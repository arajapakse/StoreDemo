using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreDemo.Application.Features.Products.Commands.CreateProduct;
using StoreDemo.Application.Features.Products.Commands.DeleteProduct;
using StoreDemo.Application.Features.Products.Commands.UpdateProduct;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Features.Products.Queries.GetProduct;
using StoreDemo.Application.Features.Products.Queries.GetProductsList;
using StoreDemo.Application.Response;
using StoreDemo.Domain.Entities;

namespace StoreDemo.Api.Controllers.Admin;

[ApiController]
[Route("adminapi/v1/Products")]
public class AdminProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(CreateProductCommand cmd)
    {
        var product = await _mediator.Send(cmd);
        return Ok(product);
    }

    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateProduct(int productId, UpdateProductCommand cmd)
    {
        cmd.ProductId = productId;

        await _mediator.Send(cmd);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        var deleteEventCommand = new DeleteProductCommand() { ProductId = productId };
        var result = await _mediator.Send(deleteEventCommand);

        if (result.Errors.Any())
        {
            return BadRequest(result);
        }

        return NoContent();
    }
}
