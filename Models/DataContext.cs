using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAdress> OrderAdresses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //public DbSet<OrderItem> OrderItems { get; set; }
            modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId, oi.ThemeId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            //public DbSet<OrderAdress> OrderAdresses { get; set; }
            modelBuilder.Entity<Order>()
            .HasOne(a => a.OrderAdress) 
            .WithOne(a => a.Order)
            .HasForeignKey<OrderAdress>(c => c.OrderId);

            //30000 validation warning
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(10, 6)");
            }

        }
    }
}
