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
    public async Task<List<ProductMV>> GetProducts()
    {
        var products = await _httpClient.GetFromJsonAsync<List<ProductMV>>("/api/v1/Products");

        return products;
    }
}
