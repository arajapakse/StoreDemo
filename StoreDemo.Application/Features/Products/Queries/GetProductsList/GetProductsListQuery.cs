using MediatR;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Response;

namespace StoreDemo.Application.Features.Products.Queries.GetProductsList;
public record GetProductsListQuery : IRequest<BaseResponse<List<ProductsVm>>>
{
}
