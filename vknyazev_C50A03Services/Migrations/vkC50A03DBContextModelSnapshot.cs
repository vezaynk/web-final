﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vknyazev_C50A03Services.Models;

namespace vknyazev_C50A03Services.Migrations
{
    [DbContext(typeof(vkC50A03DBContext))]
    partial class vkC50A03DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vknyazev_C50A03Services.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartId");

                    b.Property<int>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("vknyazev_C50A03Services.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreditCad");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Province");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("vknyazev_C50A03Services.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateFulfilled");

                    b.Property<int>("OrderCustId");

                    b.Property<decimal>("Taxes");

                    b.Property<decimal>("Total");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderCustId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("vknyazev_C50A03Services.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<int>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("vknyazev_C50A03Services.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("BuyPrice")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Manufacturer")
                        .IsRequired();

                    b.Property<int?>("ProdCatId")
                        .IsRequired();

                    b.Property<decimal?>("SellPrice")
                        .IsRequired();

                    b.Property<int?>("Stock")
                        .IsRequired();

                    b.HasKey("ProductId");

                    b.HasIndex("ProdCatId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("vknyazev_C50A03Services.Models.ProductCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProdCat");

                    b.HasKey("CategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("vknyazev_C50A03Services.Models.ShoppingCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartCustId");

                    b.Property<DateTime>("DateCreated");

                    b.HasKey("CartId");

                    b.HasIndex("CartCustId")
                        .IsUnique();

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("vknyazev_C50A03Services.Models.CartItem", b =>
                {
                    b.HasOne("vknyazev_C50A03Services.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vknyazev_C50A03Services.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vknyazev_C50A03Services.Models.Order", b =>
                {
                    b.HasOne("vknyazev_C50A03Services.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("OrderCustId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vknyazev_C50A03Services.Models.OrderItem", b =>
                {
                    b.HasOne("vknyazev_C50A03Services.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vknyazev_C50A03Services.Models.Product", b =>
                {
                    b.HasOne("vknyazev_C50A03Services.Models.ProductCategory", "ProdCat")
                        .WithMany("Products")
                        .HasForeignKey("ProdCatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vknyazev_C50A03Services.Models.ShoppingCart", b =>
                {
                    b.HasOne("vknyazev_C50A03Services.Models.Customer", "Customer")
                        .WithOne("ShoppingCart")
                        .HasForeignKey("vknyazev_C50A03Services.Models.ShoppingCart", "CartCustId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
