using AutoMapper;
using Moq;
using Shouldly;
using StoreDemo.Application.Contracts.Persistence;
using StoreDemo.Application.Features.Products.Common;
using StoreDemo.Application.Features.Products.Queries.GetProductsList;
using StoreDemo.Application.Profiles;
using StoreDemo.Application.Response;
using StoreDemo.Application.UnitTest.Mocks;
using StoreDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDemo.Application.UnitTest.Products.Queries;
public class GetProductsListQueryHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IProductRepository> _mockProductRepository;

    public GetProductsListQueryHandlerTest()
    {
        _mockProductRepository = RepositoryMocks.GetProductRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task GetProductsListTest()
    {
        var handler = new GetProductsListQueryHandler(_mapper, _mockProductRepository.Object);

        var result = await handler.Handle(new GetProductsListQuery(), CancellationToken.None);

        result.ShouldBeOfType<BaseResponse<List<ProductsVm>>>();
        
        result.Result.Count.ShouldBe(3);
    }
}
