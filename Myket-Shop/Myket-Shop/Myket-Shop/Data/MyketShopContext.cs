using Microsoft.EntityFrameworkCore;
using Myket_Shop.Models;

namespace Myket_Shop.Data
{
    public class MyketShopContext:DbContext
    {
        public MyketShopContext(DbContextOptions<MyketShopContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new { t.CategoryId, t.ProductId });
            modelBuilder.Entity<Item>(i => { i.Property(w => w.Price).HasColumnType("Money"); i.HasKey(w => w.Id); });
            #region Seed Data Category

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "موبایل",
                Description = "فروش موبایل"
            }, new Category
            {
                Id = 2,
                Name = "ساعت مجی",
                Description = "ساعت مجی"
            }, new Category
            {
                Id = 3,
                Name = "لباس",
                Description = "لباس"
            }, new Category
            {
                Id = 4,
                Name = "لوازم خانگی",
                Description = "لوازم خانگی"
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 1,
                Price = 236.0M,
                QuantityInStock = 5
            }, new Item
            {
                Id = 2,
                Price = 899.0M,
                QuantityInStock = 6
            }, new Item
            {
                Id = 3,
                Price = 300.0M,
                QuantityInStock = 7
            }, new Item
            {
                Id = 4,
                Price = 100.0M,
                QuantityInStock = 12
            }, new Item
            {
                Id = 5,
                Price = 120.0M,
                QuantityInStock = 4
            }, new Item
            {
                Id = 6,
                Price = 900.0M,
                QuantityInStock = 1
            }, new Item
            {
                Id = 7,
                Price = 5100.0M,
                QuantityInStock = 2
            }, new Item
            {
                Id = 8,
                Price = 3300.0M,
                QuantityInStock = 9
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                ItemId = 1,
                Name = "دوربین مدل 2",
                Description = "I Learn Wpf"
            }, new Product
            {
                Id = 2,
                ItemId = 2,
                Name = "دوربین مدل 3",
                Description = "I Learn Full Asp.net Core Advance"
            }, new Product
            {
                Id = 3,
                ItemId = 3,
                Name = "دوربین مدل 4",
                Description = "Learn Full AnfularJs"
            }, new Product
            {
                Id = 4,
                ItemId = 4,
                Name = "دوربین مدل 5",
                Description = "Learn Full AnfularJs"
            }, new Product
            {
                Id = 5,
                ItemId = 5,
                Name = "تیشرت",
                Description = "Learn Full AnfularJs"
            }, new Product
            {
                Id = 6,
                ItemId = 6,
                Name = "لپ تاپ مدل 1",
                Description = "Learn Full AnfularJs"
            }, new Product
            {
                Id = 7,
                ItemId = 7,
                Name = "لپ تاپ مدل 2",
                Description = "Learn Full AnfularJs"
            }, new Product
            {
                Id = 8,
                ItemId = 8,
                Name = "گوشی",
                Description = "Learn Full AnfularJs"
            });
            modelBuilder.Entity<CategoryToProduct>().HasData(new CategoryToProduct
            { CategoryId = 1, ProductId = 1 }, new CategoryToProduct
            { CategoryId = 2, ProductId = 1 }, new CategoryToProduct
            { CategoryId = 3, ProductId = 1 }, new CategoryToProduct
            { CategoryId = 4, ProductId = 1 }, new CategoryToProduct
            { CategoryId = 1, ProductId = 2 }, new CategoryToProduct
            { CategoryId = 2, ProductId = 2 }, new CategoryToProduct
            { CategoryId = 3, ProductId = 2 }, new CategoryToProduct
            { CategoryId = 4, ProductId = 2 }, new CategoryToProduct
            { CategoryId = 1, ProductId = 3 }, new CategoryToProduct
            { CategoryId = 2, ProductId = 3 }, new CategoryToProduct
            { CategoryId = 3, ProductId = 3 }, new CategoryToProduct
            { CategoryId = 4, ProductId = 3 }, new CategoryToProduct
            { CategoryId = 1, ProductId = 4 }, new CategoryToProduct
            { CategoryId = 2, ProductId = 4 }, new CategoryToProduct
            { CategoryId = 3, ProductId = 4 }, new CategoryToProduct
            { CategoryId = 4, ProductId = 4 }, new CategoryToProduct
            { CategoryId = 1, ProductId = 5 }, new CategoryToProduct
            { CategoryId = 2, ProductId = 5 }, new CategoryToProduct
            { CategoryId = 3, ProductId = 5 }, new CategoryToProduct
            { CategoryId = 4, ProductId = 5 }, new CategoryToProduct
            { CategoryId = 1, ProductId = 6 }, new CategoryToProduct
            { CategoryId = 2, ProductId = 6 }, new CategoryToProduct
            { CategoryId = 3, ProductId = 6 }, new CategoryToProduct
            { CategoryId = 4, ProductId = 6 }, new CategoryToProduct
            { CategoryId = 1, ProductId = 7 }, new CategoryToProduct
            { CategoryId = 2, ProductId = 7 }, new CategoryToProduct
            { CategoryId = 3, ProductId = 7 }, new CategoryToProduct
            { CategoryId = 4, ProductId = 7 }, new CategoryToProduct
            { CategoryId = 1, ProductId = 8 }, new CategoryToProduct
            { CategoryId = 2, ProductId = 8 }, new CategoryToProduct
            { CategoryId = 3, ProductId = 8 }, new CategoryToProduct
            { CategoryId = 4, ProductId = 8 });
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
