using StoreDemo.App.Components.Models;
using StoreDemo.App.Services;

namespace StoreDemo.App.Client.Pages;

internal class StoreApiService : IStoreApiService
{
    private HttpClient _httpClient;

    public StoreApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<ProductsResponseMV> GetProducts()
    {
        var products = await _httpClient.GetFromJsonAsync<ProductsResponseMV> ("/api/v1/Products");

        return products;
    }
}
