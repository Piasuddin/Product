using Microsoft.EntityFrameworkCore;
using MyWesite.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWesite.DAL.MyWebsiteDbContext
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Baby's Food" }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product { CategoryId = 1, Id = 1, CreatedDate = DateTime.UtcNow, Name = "Horlicks"}
            );
        }
    }
}
