﻿// <auto-generated />
using System;
using CarSales.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarSales.Data.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarSales.Data.Models.BodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BodyTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BodyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BodyTypeName = "HATCHBACK"
                        },
                        new
                        {
                            Id = 2,
                            BodyTypeName = "SEDAN"
                        },
                        new
                        {
                            Id = 3,
                            BodyTypeName = "UTE"
                        });
                });

            modelBuilder.Entity("CarSales.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BodyTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("Doors")
                        .HasColumnType("int");

                    b.Property<string>("Engine")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Wheels")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BodyTypeId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BodyTypeId = 2,
                            Created = new DateTime(2020, 10, 11, 22, 38, 11, 395, DateTimeKind.Local).AddTicks(9515),
                            Doors = 4,
                            Engine = "AUTO",
                            Make = "Toyota",
                            Model = "Camry",
                            Price = 25000m,
                            VehicleTypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 2,
                            BodyTypeId = 1,
                            Created = new DateTime(2020, 10, 11, 22, 38, 11, 400, DateTimeKind.Local).AddTicks(828),
                            Doors = 4,
                            Engine = "AUTO",
                            Make = "Toyota",
                            Model = "Corolla",
                            Price = 15000m,
                            VehicleTypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 3,
                            BodyTypeId = 3,
                            Created = new DateTime(2020, 10, 11, 22, 38, 11, 400, DateTimeKind.Local).AddTicks(894),
                            Doors = 2,
                            Engine = "AUTO",
                            Make = "Toyota",
                            Model = "Hilux",
                            Price = 35000m,
                            VehicleTypeId = 1,
                            Wheels = 4
                        },
                        new
                        {
                            Id = 4,
                            BodyTypeId = 3,
                            Created = new DateTime(2020, 10, 11, 22, 38, 11, 400, DateTimeKind.Local).AddTicks(901),
                            Doors = 2,
                            Engine = "AUTO",
                            Make = "Toyota",
                            Model = "HiAce",
                            Price = 30000m,
                            VehicleTypeId = 1,
                            Wheels = 4
                        });
                });

            modelBuilder.Entity("CarSales.Data.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VehicleTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            VehicleTypeName = "Car"
                        },
                        new
                        {
                            Id = 2,
                            VehicleTypeName = "Boat"
                        },
                        new
                        {
                            Id = 3,
                            VehicleTypeName = "Bike"
                        });
                });

            modelBuilder.Entity("CarSales.Data.Models.Car", b =>
                {
                    b.HasOne("CarSales.Data.Models.BodyType", "BodyType")
                        .WithMany()
                        .HasForeignKey("BodyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarSales.Data.Models.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
