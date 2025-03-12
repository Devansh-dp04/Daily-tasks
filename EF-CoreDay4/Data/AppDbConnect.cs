using EF_CoreDay4.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CoreDay4.Data
{
    public class AppDbConnect : DbContext
    {
        public AppDbConnect(DbContextOptions<AppDbConnect> options) : base(options)
        { }

        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.OrderProduct> OrderProducts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                        .HasIndex(c => c.Email)
                        .IsUnique();

            modelBuilder.Entity<Order>()
                        .HasOne(c => c.Customer)
                        .WithMany(o => o.Orders)
                        .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderProduct>()
                        .HasOne(o => o.Order)
                        .WithMany(Order => Order.OrderProducts)
                        .HasForeignKey(o => o.OrderId);
            
            modelBuilder.Entity<OrderProduct>()
                        .HasOne(p => p.Product)
                        .WithMany(Product => Product.OrderProducts)
                        .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });
            var fixedDate = new DateTime(2025, 03, 04, 0, 0, 0, DateTimeKind.Utc);
            modelBuilder.Entity<Customer>().HasData(
    new Customer { Id = 1, Name = "John Doe", Email = "john@example.com", CreatedDate = fixedDate, IsVIP = true },
    new Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com", CreatedDate = fixedDate, IsVIP = false },
    new Customer { Id = 3, Name = "Alice Brown", Email = "alice@example.com", CreatedDate = fixedDate, IsVIP = true },
    new Customer { Id = 4, Name = "Bob Johnson", Email = "bob@example.com", CreatedDate = fixedDate, IsVIP = false },
    new Customer { Id = 5, Name = "Charlie White", Email = "charlie@example.com", CreatedDate = fixedDate, IsVIP = true }
);

            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Price = 1200.99m, Stock = 10 },
            new Product { Id = 2, Name = "Smartphone", Price = 799.49m, Stock = 15 },
            new Product { Id = 3, Name = "Tablet", Price = 499.99m, Stock = 20 },
            new Product { Id = 4, Name = "Headphones", Price = 199.99m, Stock = 30 },
            new Product { Id = 5, Name = "Smartwatch", Price = 299.99m, Stock = 25 }
        );

           modelBuilder.Entity<Order>().HasData(
           new Order { Id = 1, OrderDate = fixedDate, CustomerId = 1, IsDeleted = false },
           new Order { Id = 2, OrderDate = fixedDate, CustomerId = 2, IsDeleted = false },
           new Order { Id = 3, OrderDate = fixedDate, CustomerId = 3, IsDeleted = false },
           new Order { Id = 4, OrderDate = fixedDate, CustomerId = 4, IsDeleted = false },
           new Order { Id = 5, OrderDate = fixedDate, CustomerId = 5, IsDeleted = false }
       );

            modelBuilder.Entity<OrderProduct>().HasData(
            new OrderProduct { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
            new OrderProduct { Id = 2, OrderId = 1, ProductId = 2, Quantity = 2 },
            new OrderProduct { Id = 3, OrderId = 2, ProductId = 3, Quantity = 1 },
            new OrderProduct { Id = 4, OrderId = 3, ProductId = 4, Quantity = 3 },
            new OrderProduct { Id = 5, OrderId = 4, ProductId = 5, Quantity = 2 },
            new OrderProduct { Id = 6, OrderId = 5, ProductId = 5, Quantity = 2 }
        );

        }
    }
}
