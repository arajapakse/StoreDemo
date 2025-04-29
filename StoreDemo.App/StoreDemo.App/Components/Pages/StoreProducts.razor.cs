using Microsoft.AspNetCore.Components;
using StoreDemo.App.Components.Models;
using StoreDemo.App.Services;

namespace StoreDemo.App.Components.Pages;

public partial class StoreProducts
{
    [Inject]
    private IStoreApiService StoreApiService { get; set; }

    private List<ProductMV> Products = default!;

    protected override async Task OnInitializedAsync()
    {
        if (StoreApiService is not null)
        {
            Products = await StoreApiService.GetProducts();
        }
    }
}
