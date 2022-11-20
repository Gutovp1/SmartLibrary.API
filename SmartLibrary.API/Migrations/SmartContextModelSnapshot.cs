﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartLibrary.API.Data;

#nullable disable

namespace SmartLibrary.API.Migrations
{
    [DbContext(typeof(SmartContext))]
    partial class SmartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("SmartLibrary.API.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PublisherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.HasIndex("UserId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Machado de Assis",
                            PublisherId = 1,
                            Quantity = 10,
                            QuantityAvailable = 10,
                            Title = "D. Casmurro",
                            Year = 1888
                        },
                        new
                        {
                            Id = 2,
                            Author = "Machado de Assis",
                            PublisherId = 1,
                            Quantity = 10,
                            QuantityAvailable = 10,
                            Title = "Capitu",
                            Year = 1888
                        },
                        new
                        {
                            Id = 3,
                            Author = "Machado de Assis",
                            PublisherId = 1,
                            Quantity = 10,
                            QuantityAvailable = 10,
                            Title = "Memorias Postumas BC",
                            Year = 1888
                        },
                        new
                        {
                            Id = 4,
                            Author = "Joao Guimaraes Rosa",
                            PublisherId = 2,
                            Quantity = 10,
                            QuantityAvailable = 10,
                            Title = "Sagarana",
                            Year = 1988
                        },
                        new
                        {
                            Id = 5,
                            Author = "Joao Guimaraes Rosa",
                            PublisherId = 2,
                            Quantity = 10,
                            QuantityAvailable = 10,
                            Title = "Manoelzao",
                            Year = 1988
                        },
                        new
                        {
                            Id = 6,
                            Author = "Joao Guimaraes Rosa",
                            PublisherId = 2,
                            Quantity = 10,
                            QuantityAvailable = 10,
                            Title = "Grande Sertao: Veredas",
                            Year = 1988
                        },
                        new
                        {
                            Id = 7,
                            Author = "Paulo Coelho",
                            PublisherId = 3,
                            Quantity = 10,
                            QuantityAvailable = 10,
                            Title = "O Alquimista",
                            Year = 1998
                        },
                        new
                        {
                            Id = 8,
                            Author = "Paulo Coelho",
                            PublisherId = 3,
                            Quantity = 10,
                            QuantityAvailable = 10,
                            Title = "O Mensageiro",
                            Year = 1998
                        },
                        new
                        {
                            Id = 9,
                            Author = "Aloisio Azevedo",
                            PublisherId = 4,
                            Quantity = 10,
                            QuantityAvailable = 10,
                            Title = "O Cortiço",
                            Year = 1888
                        });
                });

            modelBuilder.Entity("SmartLibrary.API.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "São Paulo",
                            Name = "Pearson"
                        },
                        new
                        {
                            Id = 2,
                            City = "BH",
                            Name = "Bookman"
                        },
                        new
                        {
                            Id = 3,
                            City = "Curitiba",
                            Name = "Pocket"
                        },
                        new
                        {
                            Id = 4,
                            City = "São Paulo",
                            Name = "Freedom"
                        });
                });

            modelBuilder.Entity("SmartLibrary.API.Models.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReturnRealDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Rentals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 2,
                            RentDate = new DateTime(2022, 11, 20, 13, 49, 38, 354, DateTimeKind.Local).AddTicks(5587),
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            RentDate = new DateTime(2022, 11, 20, 13, 49, 38, 354, DateTimeKind.Local).AddTicks(5609),
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 4
                        },
                        new
                        {
                            Id = 3,
                            BookId = 4,
                            RentDate = new DateTime(2022, 11, 20, 13, 49, 38, 354, DateTimeKind.Local).AddTicks(5612),
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            BookId = 1,
                            RentDate = new DateTime(2022, 11, 20, 13, 49, 38, 354, DateTimeKind.Local).AddTicks(5613),
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            BookId = 3,
                            RentDate = new DateTime(2022, 11, 20, 13, 49, 38, 354, DateTimeKind.Local).AddTicks(5615),
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3
                        },
                        new
                        {
                            Id = 6,
                            BookId = 5,
                            RentDate = new DateTime(2022, 11, 20, 13, 49, 38, 354, DateTimeKind.Local).AddTicks(5618),
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            Id = 7,
                            BookId = 5,
                            RentDate = new DateTime(2022, 11, 20, 13, 49, 38, 354, DateTimeKind.Local).AddTicks(5620),
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 4
                        });
                });

            modelBuilder.Entity("SmartLibrary.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Campeche",
                            City = "Floripa",
                            Email = "avp@avp.com",
                            Name = "Augusto"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Morro",
                            City = "Pocos",
                            Email = "dvp@dvp.com",
                            Name = "Diogo"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Lourdes",
                            City = "BH",
                            Email = "acvp@acvp.com",
                            Name = "Caia"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Bronx",
                            City = "Dublin",
                            Email = "aevp@aevp.com",
                            Name = "Ne"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Campeche",
                            City = "Floripa",
                            Email = "lca@lca.com",
                            Name = "Larissa"
                        },
                        new
                        {
                            Id = 6,
                            Address = "Lourdes",
                            City = "BH",
                            Email = "dbi@dbi.com",
                            Name = "Dan"
                        });
                });

            modelBuilder.Entity("SmartLibrary.API.Models.Book", b =>
                {
                    b.HasOne("SmartLibrary.API.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartLibrary.API.Models.User", null)
                        .WithMany("Books")
                        .HasForeignKey("UserId");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("SmartLibrary.API.Models.Rental", b =>
                {
                    b.HasOne("SmartLibrary.API.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartLibrary.API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartLibrary.API.Models.User", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
