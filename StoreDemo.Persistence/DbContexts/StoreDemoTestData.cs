using Microsoft.EntityFrameworkCore;
using StoreDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDemo.Persistence.DbContexts;
internal static class StoreDemoTestData
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        var battingEquipment = new Category()
        {
            CategoryId = 1,
            Name = "Baseball Batting Equipment",
            Description = "Baseball batting gear"
        };

        var fieldingEquipment= new Category()
        {
            CategoryId = 2,
            Name = "Baseball Fielding  Equipment",
            Description = "Baseball fielding gear"
        };

        var runningEquipment = new Category()
        {
            CategoryId = 3,
            Name = "Baseball Running  Equipment",
            Description = "Baseball running gear"
        };

        var apparel = new Category()
        {
            CategoryId = 4,
            Name = "Baseball Apparel",
            Description = "Baseball apparels"
        };

        var baseballDrip = new Category()
        {
            CategoryId = 5,
            Name = "Baseball accessories",
            Description = "Baseball drip isn't just about flashy accessories"
        };

        var bat1 = new Product()
        {
            ProductId = 1,
            Name = "Bonesaber",
            CategoryId = battingEquipment.CategoryId,
            Description = "Baseball bat",
            Price = 249.00m,
            StockQuantity = 20,
            ImageUrl = "/images/bonesaber.jpg"

        };

        var bat2 = new Product()
        {
            ProductId = 2,
            Name = "Louisville Slugger",
            CategoryId = battingEquipment.CategoryId,
            Description = "Baseball bat",
            Price = 210.00m,
            StockQuantity = 15,
            ImageUrl = "/images/louisville_slugger.jpg"

        };

        var bat3 = new Product()
        {
            ProductId = 3,
            Name = "Marucci catx2",
            CategoryId = battingEquipment.CategoryId,
            Description = "Baseball bat",
            Price = 199.00m,
            StockQuantity = 5,
            ImageUrl = "/images/marucci.jpg"

        };

        var bat4 = new Product()
        {
            ProductId = 4,
            Name = "Easton",
            CategoryId = battingEquipment.CategoryId,
            Description = "Baseball bat",
            Price = 177.00m,
            StockQuantity = 5,
            ImageUrl = "/images/easton.jpg"

        };


        modelBuilder.Entity<Category>().HasData(battingEquipment);
        modelBuilder.Entity<Category>().HasData(fieldingEquipment);
        modelBuilder.Entity<Category>().HasData(runningEquipment);
        modelBuilder.Entity<Category>().HasData(apparel);
        modelBuilder.Entity<Category>().HasData(baseballDrip);

        modelBuilder.Entity<Product>().HasData(bat1);
        modelBuilder.Entity<Product>().HasData(bat2);
        modelBuilder.Entity<Product>().HasData(bat3);
        modelBuilder.Entity<Product>().HasData(bat4);
    }
}
