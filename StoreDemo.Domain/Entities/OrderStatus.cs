using System.ComponentModel.DataAnnotations;

namespace StoreDemo.Domain.Entities;

public enum OrderStatus
{
    [Display(Name = "Processing")]
    Processing,
    [Display(Name = "Shipped")]
    Shipped,
    [Display(Name = "Delivered")]
    Delivered,
    [Display(Name = "Cancelled")]
    Cancelled
}