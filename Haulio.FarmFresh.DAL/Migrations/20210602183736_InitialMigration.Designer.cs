﻿// <auto-generated />
using Haulio.FarmFresh.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Haulio.FarmFresh.DAL.Migrations
{
    [DbContext(typeof(FarmFreshDbContext))]
    [Migration("20210602183736_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Haulio.FarmFresh.Entity.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryofOrigin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CountryofOrigin = "France",
                            Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Tomato.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                            ImageUrl = "images/tomato.png",
                            ProductName = "Tomato",
                            Unit = "Packet"
                        },
                        new
                        {
                            ProductId = 2,
                            CountryofOrigin = "Germany",
                            Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Salmon.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                            ImageUrl = "images/salmon.png",
                            ProductName = "Salmon",
                            Unit = "Packet"
                        },
                        new
                        {
                            ProductId = 3,
                            CountryofOrigin = "Greece",
                            Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Capsicum.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                            ImageUrl = "images/capsicum.png",
                            ProductName = "Capsicum",
                            Unit = "Packet"
                        },
                        new
                        {
                            ProductId = 4,
                            CountryofOrigin = "Poland",
                            Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Ripe Blue Grapes.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                            ImageUrl = "images/ripe_blue_grapes.png",
                            ProductName = "Ripe Blue Grapes",
                            Unit = "Packet"
                        },
                        new
                        {
                            ProductId = 5,
                            CountryofOrigin = "Swiss",
                            Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Spinach.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                            ImageUrl = "images/spinach.png",
                            ProductName = "Spinach",
                            Unit = "Packet"
                        },
                        new
                        {
                            ProductId = 6,
                            CountryofOrigin = "Indonesia",
                            Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Broccoli.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                            ImageUrl = "images/broccoli.png",
                            ProductName = "Broccoli",
                            Unit = "Packet"
                        },
                        new
                        {
                            ProductId = 7,
                            CountryofOrigin = "Australia",
                            Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Pepper.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                            ImageUrl = "images/pepper.png",
                            ProductName = "Pepper",
                            Unit = "Packet"
                        },
                        new
                        {
                            ProductId = 8,
                            CountryofOrigin = "Rusia",
                            Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Eggplant.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                            ImageUrl = "images/eggplant.png",
                            ProductName = "Eggplant",
                            Unit = "Packet"
                        },
                        new
                        {
                            ProductId = 9,
                            CountryofOrigin = "Singapore",
                            Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Carrot.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                            ImageUrl = "images/carrot.png",
                            ProductName = "Carrot",
                            Unit = "Packet"
                        },
                        new
                        {
                            ProductId = 10,
                            CountryofOrigin = "Mexico",
                            Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Spinach.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                            ImageUrl = "images/spinach.png",
                            ProductName = "Spinach",
                            Unit = "Packet"
                        },
                        new
                        {
                            ProductId = 11,
                            CountryofOrigin = "Italy",
                            Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Pear.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                            ImageUrl = "images/pear.png",
                            ProductName = "Pear",
                            Unit = "Packet"
                        });
                });

            modelBuilder.Entity("Haulio.FarmFresh.Entity.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Haulio",
                            Password = "728C9600B6B6C808117068532E9585F1B757063B22EE84A3B1FF6BF2D8BA9F16BCA73ABA7504642465763BB429DE97E70DFE8FC749E9B2CB6C4A57D89FC7B738",
                            Username = "Haulio"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
