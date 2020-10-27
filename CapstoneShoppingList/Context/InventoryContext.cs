using CapstoneShoppingList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneShoppingList.Context
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }
        public virtual DbSet<Products> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Inventory;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(p =>
            {
                p.HasKey(e => e.ProductID);

                p.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(30);

                p.Property(e => e.ProductPrice).
                IsRequired();
            });

            modelBuilder.Entity<Products>().HasData(
                new Products { ProductID = 1, ProductName = "Candy", ProductPrice = 1.99M },
                new Products { ProductID = 2, ProductName = "Chips", ProductPrice = 3.99M },
                new Products { ProductID = 3, ProductName = "Pop", ProductPrice = .99M },
                new Products { ProductID = 4, ProductName = "Pizza", ProductPrice = 5.00M }
                );
        }
     }
}
