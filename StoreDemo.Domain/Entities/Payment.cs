﻿namespace StoreDemo.Domain.Entities;

public class Payment
{
    public int PaymentId { get; set; }
    public int OrderId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public string PaymentMethod { get; set; }
    public Order Order { get; set; }
}