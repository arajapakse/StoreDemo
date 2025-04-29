using MediatR;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Response;
using StoreDemo.Domain.Entities;

namespace StoreDemo.Application.Features.Products.Queries.GetProduct;
// Ensure GetProductQuery implements IRequest<ProductsVm>
public record GetProductQuery : IRequest<BaseResponse<ProductsVm>>
{
    public int ProductId { get; set; }
}
