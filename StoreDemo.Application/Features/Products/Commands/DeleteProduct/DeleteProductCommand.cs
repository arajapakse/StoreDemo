using MediatR;
using StoreDemo.Application.Features.Products.Commands.UpdateProduct;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Response;
using StoreDemo.Domain.Entities;

namespace StoreDemo.Application.Features.Products.Commands.DeleteProduct;
// Ensure DeleteProductCommand implements IRequest<BaseResponse>
public record DeleteProductCommand : IRequest<BaseResponse>
{
    public int ProductId { get; set; }
}
