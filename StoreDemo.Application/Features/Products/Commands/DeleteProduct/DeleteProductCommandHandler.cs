
using AutoMapper;
using MediatR;
using StoreDemo.Application.Contracts.Persistence;
using StoreDemo.Application.Response;

namespace StoreDemo.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, BaseResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<BaseResponse> Handle(DeleteProductCommand productDeleteCommand, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(productDeleteCommand.ProductId);

        if (product == null)
        {
            return new BaseResponse
            {
                Errors = new List<string> { "Product not found." }
            };
        }

        await _productRepository.DeleteAsync(product);

        return new BaseResponse();
    }
}
