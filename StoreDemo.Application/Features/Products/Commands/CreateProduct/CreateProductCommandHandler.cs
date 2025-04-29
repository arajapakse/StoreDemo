using AutoMapper;
using MediatR;
using StoreDemo.Application.Contracts.Persistence;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Response;
using StoreDemo.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace StoreDemo.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse<ProductsVm>>
{
    private readonly IProductRepository _productRepository;
    private readonly CreateProductCommandValidator _createProductCommandValidator;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository, 
        CreateProductCommandValidator createProductCommandValidator)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _createProductCommandValidator = createProductCommandValidator;
    }

    public async Task<BaseResponse<ProductsVm>> Handle(CreateProductCommand productCreateCommand, CancellationToken cancellationToken)
    {
        var validationResult = await _createProductCommandValidator.ValidateAsync(productCreateCommand);

        if (validationResult.Errors.Count > 0)
        {
            var response = new BaseResponse<ProductsVm>();

            foreach (var error in validationResult.Errors)
            {
                response.Errors.Add(error.ErrorMessage);
            }

            return response;
        }


        var product = _mapper.Map<Product>(productCreateCommand);

        await _productRepository.AddAsync(product);

        return _mapper.Map<BaseResponse<ProductsVm>>(product);
    }
}
