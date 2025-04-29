
using AutoMapper;
using MediatR;
using StoreDemo.Application.Contracts.Persistence;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Response;
using StoreDemo.Domain.Entities;

namespace StoreDemo.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseResponse<ProductsVm>>
{
    private readonly IProductRepository _productRepository;
    private readonly UpdateProductCommandValidator _updateProductCommandValidator;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository,
        UpdateProductCommandValidator updateProductCommandValidator)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _updateProductCommandValidator = updateProductCommandValidator;
    }

    public async Task<BaseResponse<ProductsVm>> Handle(UpdateProductCommand productUpdateCommand, CancellationToken cancellationToken)
    {
        var validationResult = await _updateProductCommandValidator.ValidateAsync(productUpdateCommand);
        
        if (validationResult.Errors.Count > 0)
        {
            var response = new BaseResponse<ProductsVm>();

            foreach (var error in validationResult.Errors)
            {
                response.Errors.Add(error.ErrorMessage);
            }

            return response;
        }


        var product = _mapper.Map<Product>(productUpdateCommand);

        await _productRepository.UpdateAsync(product);

        return _mapper.Map<BaseResponse<ProductsVm>>(product);
    }
}
