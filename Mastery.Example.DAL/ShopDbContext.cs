﻿using System.Data.Entity;
using Mystery.Example.DAL.Common.Models.Customer;
using Mystery.Example.DAL.Common.Models.Product;

namespace Mystery.Example.DAL
{
    public class ShopDbContext : System.Data.Entity.DbContext
    {
        public ShopDbContext() : base("ShopStore") { }

        public DbSet<CustomerDbModel> Customers { get; set; }
        public DbSet<ProductDbModel> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDbModel>().ToTable("Customers");
            modelBuilder.Entity<ProductDbModel>().ToTable("Products");

            modelBuilder.Entity<CustomerDbModel>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Customers)
                .Map(m =>
                {
                    m.ToTable("Orders");

                    m.MapLeftKey("CustomerId");
                    m.MapRightKey("ProductId");
                });
        }
    }
}