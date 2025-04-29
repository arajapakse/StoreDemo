using StoreDemo.App.Components.Models;

namespace StoreDemo.App.Services;

internal interface IStoreApiService
{
    Task<List<ProductMV>> GetProducts();
}
