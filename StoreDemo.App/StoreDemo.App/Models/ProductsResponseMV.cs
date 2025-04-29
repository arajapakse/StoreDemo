namespace StoreDemo.App.Components.Models;

public record ProductsResponseMV
{
    public List<ProductMV> Result { get; set; }
    public string[] Errors { get; set; }
}