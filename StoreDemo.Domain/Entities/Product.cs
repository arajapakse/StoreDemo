using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDemo.Domain.Entities;

public class Product
{
    public int ProductId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    [Column(TypeName = "decimal(18,2)")]

    public decimal Price { get; set; } = default!;
    public int StockQuantity { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public string? ImageUrl { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}
