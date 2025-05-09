﻿using MediatR;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Response;

namespace StoreDemo.Application.Features.Products.Commands.CreateProduct;
public class CreateProductCommand : IRequest<BaseResponse<ProductsVm>>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }
    public string? ImageUrl { get; set; }
}
