using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Features.Products.Queries.GetProduct;
using StoreDemo.Application.Features.Products.Queries.GetProductsList;
using StoreDemo.Application.Response;
using StoreDemo.Domain.Entities;

namespace StoreDemo.Api.Controllers;

[ApiController]
[Route("api/v1/Products")]

public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponse<List<ProductsVm>>>> GetProducts()
    {
        var productsResult = await _mediator.Send(new GetProductsListQuery());

        return Ok(productsResult);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<ProductsVm>>> GetProduct(int id)
    {
        var productResult = new GetProductQuery() { ProductId = id };
        var result = await _mediator.Send(productResult);

        return Ok(result);
    }
}
