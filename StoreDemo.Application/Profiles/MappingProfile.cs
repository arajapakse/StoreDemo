using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreDemo.Application.Features.Products.Commands.CreateProduct;
using StoreDemo.Application.Features.Products.Commands.UpdateProduct;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Response;
using StoreDemo.Domain.Entities;


namespace StoreDemo.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductsVm>()
                .ForMember(p => p.CategoryId, opt => opt.MapFrom(p => p.CategoryId))
                .ForMember(p => p.Category, opt => opt.MapFrom(p => p.Category.Name))
                .ReverseMap();

            CreateMap<Product, BaseResponse<ProductsVm>>()
                .ForMember(p => p.Result, opt => opt.MapFrom(p => new ProductsVm()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId ?? 0,
                    Category = p.Category != null ? p.Category.Name : string.Empty,
                    ImageUrl = p.ImageUrl ?? string.Empty
                } ));

            CreateMap<List<Product>, BaseResponse<List<ProductsVm>>>()
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Select(product => new ProductsVm
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity,
                    CategoryId = product.CategoryId ?? 0,
                    Category = product.Category != null ? product.Category.Name : string.Empty,
                    ImageUrl = product.ImageUrl ?? string.Empty
                }).ToList()));

            // 
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}



