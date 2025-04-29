using AutoMapper;
using MediatR;
using StoreDemo.Application.Contracts.Persistence;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Response;
using StoreDemo.Domain.Entities;

namespace StoreDemo.Application.Features.Products.Queries.GetProductsList;

public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, BaseResponse<List<ProductsVm>>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsListQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<BaseResponse<List<ProductsVm>>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {       
        var products = await _productRepository.GetAllProductsSortedByNameAsync();

        return _mapper.Map<BaseResponse<List<ProductsVm>>>(products);
    }
}