using Microsoft.EntityFrameworkCore;
using MyWesite.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWesite.DAL.MyWebsiteDbContext
{
    public class MyWebsiteDataDbContext: DbContext
    {
        public MyWebsiteDataDbContext(DbContextOptions<MyWebsiteDataDbContext> Options) : base(Options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
