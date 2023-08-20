
﻿using cassiopeia_be.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cassiopeia_be.Data
{
    public class CassiopeiaContext : DbContext
    {
        public DbSet<SatelliteInfo> SatelliteInfos { get; set; }

        public DbSet<AprsMessage> AprsMessages { get; set; }

        public CassiopeiaContext(DbContextOptions<CassiopeiaContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SatelliteInfo>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
                // Configure other properties as needed
            });

            modelBuilder.Entity<SatelliteInfo>().HasData(
                new SatelliteInfo
                {
                    Id = 1,
                    Name = "cassiopeia",
                    Image = "https://some_random_image.jpg",
                    LaunchDate = DateTime.Parse("2023-08-07T15:45:00Z"),
                    Status = "active",
                    Owner = "notch",
                    OriginCountry = "Croatia"
                });

            modelBuilder.Entity<AprsMessage>().HasData(
                new AprsMessage
                {
                    Id = 1,
                    Time = DateTime.Now,
                    Message = "Hello from CubeSat-1!",
                    Observer = "Ground Station A",
                    Station = "CubeSat-1",
                    Source = "NOCALL",
                    SatelliteId = 1 //možda neće raditi
                },
                new AprsMessage
                {
                    Id = 2,
                    Time = DateTime.Now,
                    Message = "Temperature: 25°C, Battery: 85%",
                    Observer = "Ground Station B",
                    Station = "CubeSat-2",
                    Source = "NOCALL",
                    SatelliteId = 1
                },
                new AprsMessage
                {
                    Id = 3,
                    Time = DateTime.Now,
                    Message = "Deployed solar panels successfully!",
                    Observer = "Ground Station C",
                    Station = "CubeSat-3",
                    Source = "NOCALL",
                    SatelliteId = 1
                },
                new AprsMessage
                {
                    Id = 4,
                    Time = DateTime.Now,
                    Message = "Orbit update: Altitude: 400 km, Inclination: 45°",
                    Observer = "Ground Station D",
                    Station = "CubeSat-4",
                    Source = "NOCALL",
                    SatelliteId = 1
                },
                new AprsMessage
                {
                    Id = 5,
                    Time = DateTime.Now,
                    Message = "Experiment results: Successful microgravity test.",
                    Observer = "Ground Station E",
                    Station = "CubeSat-5",
                    Source = "NOCALL",
                    SatelliteId = 1
                });
        }
    }
}

