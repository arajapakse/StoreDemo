using Microsoft.AspNetCore.Components;
using StoreDemo.App.Components.Models;
using StoreDemo.App.Services;

namespace StoreDemo.App.Components.Pages;

public partial class StoreProducts
{
    [Inject]
    private IStoreApiService StoreApiService { get; set; }

    private ProductsResponseMV ProductsResponse = default!;

    protected override async Task OnInitializedAsync()
    {
        if (StoreApiService is not null)
        {
            ProductsResponse = await StoreApiService.GetProducts();
        }
    }
}
