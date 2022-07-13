﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Myket_Shop.Data;

namespace Myket_Shop.Migrations
{
    [DbContext(typeof(MyketShopContext))]
    partial class MyketShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Myket_Shop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "فروش موبایل",
                            Name = "موبایل"
                        },
                        new
                        {
                            Id = 2,
                            Description = "ساعت مجی",
                            Name = "ساعت مجی"
                        },
                        new
                        {
                            Id = 3,
                            Description = "لباس",
                            Name = "لباس"
                        },
                        new
                        {
                            Id = 4,
                            Description = "لوازم خانگی",
                            Name = "لوازم خانگی"
                        });
                });

            modelBuilder.Entity("Myket_Shop.Models.CategoryToProduct", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CategoryToProducts");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 3
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 3
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 3
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 3
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 4
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 4
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 4
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 4
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 5
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 5
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 5
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 5
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 6
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 6
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 6
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 6
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 7
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 7
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 7
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 7
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 8
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 8
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 8
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 8
                        });
                });

            modelBuilder.Entity("Myket_Shop.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 236.0m,
                            QuantityInStock = 5
                        },
                        new
                        {
                            Id = 2,
                            Price = 899.0m,
                            QuantityInStock = 6
                        },
                        new
                        {
                            Id = 3,
                            Price = 300.0m,
                            QuantityInStock = 7
                        },
                        new
                        {
                            Id = 4,
                            Price = 100.0m,
                            QuantityInStock = 12
                        },
                        new
                        {
                            Id = 5,
                            Price = 120.0m,
                            QuantityInStock = 4
                        },
                        new
                        {
                            Id = 6,
                            Price = 900.0m,
                            QuantityInStock = 1
                        },
                        new
                        {
                            Id = 7,
                            Price = 5100.0m,
                            QuantityInStock = 2
                        },
                        new
                        {
                            Id = 8,
                            Price = 3300.0m,
                            QuantityInStock = 9
                        });
                });

            modelBuilder.Entity("Myket_Shop.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinaly")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Myket_Shop.Models.OrderDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("DetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Myket_Shop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "I Learn Wpf",
                            ItemId = 1,
                            Name = "دوربین مدل 2"
                        },
                        new
                        {
                            Id = 2,
                            Description = "I Learn Full Asp.net Core Advance",
                            ItemId = 2,
                            Name = "دوربین مدل 3"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Learn Full AnfularJs",
                            ItemId = 3,
                            Name = "دوربین مدل 4"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Learn Full AnfularJs",
                            ItemId = 4,
                            Name = "دوربین مدل 5"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Learn Full AnfularJs",
                            ItemId = 5,
                            Name = "تیشرت"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Learn Full AnfularJs",
                            ItemId = 6,
                            Name = "لپ تاپ مدل 1"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Learn Full AnfularJs",
                            ItemId = 7,
                            Name = "لپ تاپ مدل 2"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Learn Full AnfularJs",
                            ItemId = 8,
                            Name = "گوشی"
                        });
                });

            modelBuilder.Entity("Myket_Shop.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Myket_Shop.Models.CategoryToProduct", b =>
                {
                    b.HasOne("Myket_Shop.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Myket_Shop.Models.Product", "Product")
                        .WithMany("CategoryToProduct")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Myket_Shop.Models.Order", b =>
                {
                    b.HasOne("Myket_Shop.Models.Users", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Myket_Shop.Models.OrderDetail", b =>
                {
                    b.HasOne("Myket_Shop.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Myket_Shop.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Myket_Shop.Models.Product", b =>
                {
                    b.HasOne("Myket_Shop.Models.Item", "Item")
                        .WithOne("Product")
                        .HasForeignKey("Myket_Shop.Models.Product", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Myket_Shop.Models.Item", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Myket_Shop.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Myket_Shop.Models.Product", b =>
                {
                    b.Navigation("CategoryToProduct");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Myket_Shop.Models.Users", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}