﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAcademyCarBook.DataAccessLayer.Concrete;

#nullable disable

namespace MyAcademyCarBook.DataAccessLayer.Migrations
{
    [DbContext(typeof(CarBookContext))]
    [Migration("20231017193623_change_type_of_category_status")]
    partial class change_type_of_category_status
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandID"), 1L, 1);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarID"), 1L, 1);

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<int>("CarStatusId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("GearType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Km")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("PersonCount")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CarID");

                    b.HasIndex("BrandID");

                    b.HasIndex("CarStatusId");

                    b.HasIndex("CategoryID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.CarStatus", b =>
                {
                    b.Property<int>("CarStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarStatusID"), 1L, 1);

                    b.Property<string>("CarStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarStatusID");

                    b.ToTable("CarStatuses");
                });

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"), 1L, 1);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.Price", b =>
                {
                    b.Property<int>("PriceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriceID"), 1L, 1);

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<string>("PriceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PriceID");

                    b.HasIndex("CarID");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.Car", b =>
                {
                    b.HasOne("MyAcademyCarBook.EntityLayer.Concrete.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyAcademyCarBook.EntityLayer.Concrete.CarStatus", "CarStatus")
                        .WithMany("Cars")
                        .HasForeignKey("CarStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyAcademyCarBook.EntityLayer.Concrete.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("CarStatus");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.Price", b =>
                {
                    b.HasOne("MyAcademyCarBook.EntityLayer.Concrete.Car", "Car")
                        .WithMany("Prices")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.Car", b =>
                {
                    b.Navigation("Prices");
                });

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.CarStatus", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("MyAcademyCarBook.EntityLayer.Concrete.Category", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}