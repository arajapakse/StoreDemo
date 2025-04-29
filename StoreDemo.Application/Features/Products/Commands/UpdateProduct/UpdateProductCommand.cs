using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreDemo.Application.Features.Products.Commands.CreateProduct;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Response;
using System.Text.Json.Serialization;

namespace StoreDemo.Application.Features.Products.Commands.UpdateProduct;
public record UpdateProductCommand : IRequest<BaseResponse<ProductsVm>>
{
    [JsonIgnore]
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }
    public string? ImageUrl { get; set; }
}
