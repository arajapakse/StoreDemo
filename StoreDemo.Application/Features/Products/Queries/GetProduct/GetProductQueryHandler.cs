using AutoMapper;
using MediatR;
using StoreDemo.Application.Contracts.Persistence;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Response;

namespace StoreDemo.Application.Features.Products.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, BaseResponse<ProductsVm>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<BaseResponse<ProductsVm>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId);

        return _mapper.Map<BaseResponse<ProductsVm>>(product); 
    }
}
