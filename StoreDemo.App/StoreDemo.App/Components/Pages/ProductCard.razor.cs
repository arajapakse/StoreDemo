using Microsoft.AspNetCore.Components;
using StoreDemo.App.Components.Models;

namespace StoreDemo.App.Components.Pages;

public partial class ProductCard
{
    [Parameter]
    public ProductMV Product { get; set; }
}
