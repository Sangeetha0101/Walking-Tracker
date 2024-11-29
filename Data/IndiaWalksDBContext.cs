using IndiaWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace IndiaWalks.Data
{
    public class IndiaWalksDBContext : DbContext
    {
        public IndiaWalksDBContext(DbContextOptions<IndiaWalksDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for difficulties: Easy, Medium, and Hard
            var difficulties = new List<Difficulty>
            {
                new Difficulty { ID = Guid.Parse("cba97fde-b750-4005-8260-205918883587"), Name = "Easy" },
                new Difficulty { ID = Guid.Parse("c247a0ed-f6db-44b5-874c-4d4a7fdd70e7"), Name = "Medium" },
                new Difficulty { ID = Guid.Parse("ddb77ede-e1f8-44a7-b430-69d18561781a"), Name = "Hard" }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("66ec9ed1-d15b-4353-89ce-c5c7af928f43"),
                    Name = "Ambatur",
                    Code = "AMBT",
                    RegionImageUrl = "https://example.com/image1.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("c78edf4c-c08b-4535-b9d9-ad913938b4b4"),
                    Name = "Vadapalani",
                    Code = "VDP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("630d2717-c2fa-4197-ae78-55a8da2218e9"),
                    Name = "Guindy",
                    Code = "GND",
                    RegionImageUrl = "https://example.com/image3.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("e77db745-7366-41d6-844c-1a76129c6c10"),
                    Name = "Tambaram",
                    Code = "TBM",
                    RegionImageUrl = "https://example.com/image4.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("79f4a80c-bd2a-4b81-bdf9-36df63876434"),
                    Name = "Thoraipakkam",
                    Code = "TRP",
                    RegionImageUrl = "https://example.com/image5.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("69d89d97-7bb1-4edc-a40f-74ff77752bbb"),
                    Name = "AnnaNagar",
                    Code = "AN",
                    RegionImageUrl = "https://example.com/image6.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("7cd7cffb-36bb-4d57-9e22-da50b65de8cf"),
                    Name = "Saidapet",
                    Code = "SDP",
                    RegionImageUrl = "https://example.com/image7.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
