﻿using cassiopeia_be.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cassiopeia_be.Data
{
    public class CassiopeiaContext : DbContext
    {
        public DbSet<SatelliteInfo> SatelliteInfos { get; set; }

        public CassiopeiaContext(DbContextOptions<CassiopeiaContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SatelliteInfo>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<SatelliteInfo>().HasData(
                new SatelliteInfo
                {
                    Id = 1,
                    Name = "cassiopeia",
                    Image = "https://some_random_image.jpg",
                    LaunchDate = DateTime.Parse("2023-08-07T15:45:00Z"),
                    Status = true,
                    Owner = "notch",
                    OriginCountry = "Croatia"
                });
        }
    }
}
