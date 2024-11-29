﻿// <auto-generated />
using System;
using IndiaWalks.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IndiaWalks.Migrations
{
    [DbContext(typeof(IndiaWalksDBContext))]
    partial class IndWalksDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IndiaWalks.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            ID = new Guid("cba97fde-b750-4005-8260-205918883587"),
                            Name = "Easy"
                        },
                        new
                        {
                            ID = new Guid("c247a0ed-f6db-44b5-874c-4d4a7fdd70e7"),
                            Name = "Medium"
                        },
                        new
                        {
                            ID = new Guid("ddb77ede-e1f8-44a7-b430-69d18561781a"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("IndiaWalks.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("66ec9ed1-d15b-4353-89ce-c5c7af928f43"),
                            Code = "AMBT",
                            Name = "Ambatur",
                            RegionImageUrl = "https://example.com/image1.jpg"
                        },
                        new
                        {
                            Id = new Guid("c78edf4c-c08b-4535-b9d9-ad913938b4b4"),
                            Code = "VDP",
                            Name = "Vadapalani"
                        },
                        new
                        {
                            Id = new Guid("630d2717-c2fa-4197-ae78-55a8da2218e9"),
                            Code = "GND",
                            Name = "Guindy",
                            RegionImageUrl = "https://example.com/image3.jpg"
                        },
                        new
                        {
                            Id = new Guid("e77db745-7366-41d6-844c-1a76129c6c10"),
                            Code = "TBM",
                            Name = "Tambaram",
                            RegionImageUrl = "https://example.com/image4.jpg"
                        },
                        new
                        {
                            Id = new Guid("79f4a80c-bd2a-4b81-bdf9-36df63876434"),
                            Code = "TRP",
                            Name = "Thoraipakkam",
                            RegionImageUrl = "https://example.com/image5.jpg"
                        },
                        new
                        {
                            Id = new Guid("69d89d97-7bb1-4edc-a40f-74ff77752bbb"),
                            Code = "AN",
                            Name = "AnnaNagar",
                            RegionImageUrl = "https://example.com/image6.jpg"
                        },
                        new
                        {
                            Id = new Guid("7cd7cffb-36bb-4d57-9e22-da50b65de8cf"),
                            Code = "SDP",
                            Name = "Saidapet",
                            RegionImageUrl = "https://example.com/image7.jpg"
                        });
                });

            modelBuilder.Entity("IndiaWalks.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKM")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DifficultyID");

                    b.HasIndex("RegionID");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("IndiaWalks.Models.Domain.Walk", b =>
                {
                    b.HasOne("IndiaWalks.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IndiaWalks.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
