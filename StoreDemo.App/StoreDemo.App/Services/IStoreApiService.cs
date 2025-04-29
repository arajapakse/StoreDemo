using StoreDemo.App.Components.Models;

namespace StoreDemo.App.Services;

internal interface IStoreApiService
{
    Task<ProductsResponseMV> GetProducts();
}
