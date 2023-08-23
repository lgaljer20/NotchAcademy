
﻿using cassiopeia_be.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cassiopeia_be.Data
{
    public class CassiopeiaContext : DbContext
    {
        public DbSet<SatelliteInfo> SatelliteInfos { get; set; }

        public DbSet<AprsMessage> AprsMessages { get; set; }
        public DbSet<TemperatureData> TemperatureDataRecords { get; set; }
        public DbSet<BatteryCurrent> BatteryCurrentRecords { get; set; }
        public DbSet<BatteryStatus>BatteryStatuses { get; set; }

        public CassiopeiaContext(DbContextOptions<CassiopeiaContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SatelliteInfo>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<TemperatureData>(entity =>
            {
                entity.Property(e => e.Timestamp).IsRequired();
                entity.Property(e => e.BatteryTemperature).IsRequired();
                entity.Property(e => e.SystemTemperature).IsRequired();
            });

            modelBuilder.Entity<SatelliteInfo>().HasData(
                new SatelliteInfo
                {
                    Id = 1,
                    Name = "cassiopeia",
                    Image = "https://some_random_image.jpg",
                    LaunchDate = DateTime.Parse("2023-08-07T15:45:00Z"),
                    StatusIsEnabled = true,
                    Owner = "notch",
                    OriginCountry = "Croatia",
                    ReceivedByIsEnabled = true,
                    SignalCountIsEnabled = true,
                    APRSIsEnabled = true,
                    BatteryVoltageIsEnabled = true,
                    BatteryCapacityIsEnabled = true,
                    BatteryTemperatureIsEnabled = true,
                    SolarTemperatureIsEnabled = true,
                    UHFTemperatureIsEnabled = true,
                    VHFTemperatureIsEnabled = true,
                    OBC9DOTemperatureIsEnabled = true,
                    OBCNumberIsEnabled = true,
                    OBCPacketRecordIsEnabled = true,
                    OBCTimestampIsEnabled = true,
                    OBCMCUTemperatureIsEnabled = true,
                    OBCUptimeTotalIsEnabled = true,
                    OBCRestartIsEnabled = true,
                    OBCFreeMemoryIsEnabled = true
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
            modelBuilder.Entity<Battery>()
                   .HasOne(b => b.SatelliteInfo)
                   .WithMany(si => si.Batteries)
                   .HasForeignKey(b => b.SatelliteId);


            modelBuilder.Entity<Battery>()
                 .HasMany(b => b.BatteryStatuses)
                 .WithOne(bs => bs.Battery)
                 .HasForeignKey(bs => bs.BatteryId);

            modelBuilder.Entity<Battery>()
                .HasMany(b => b.TemperatureDataRecords)
                .WithOne(td => td.Battery)
                .HasForeignKey(td => td.BatteryId);

            modelBuilder.Entity<Battery>()
                .HasMany(b => b.BatteryCurrents)
                .WithOne(bc => bc.Battery)
                .HasForeignKey(bc => bc.BatteryId);

            modelBuilder.Entity<Battery>().HasData(
                new Battery 
                { Id = 1 },
                new Battery 
                { Id = 2 });

            modelBuilder.Entity<BatteryStatus>().HasData(
                new BatteryStatus { BatteryId = 1, Voltage = 12.5, Current = 5.0, ChargeLevel = 80 },
                new BatteryStatus { BatteryId = 2, Voltage = 13.2, Current = 4.8, ChargeLevel = 75 }
            );

            modelBuilder.Entity<TemperatureData>().HasData(
                new TemperatureData { BatteryId = 1, Timestamp = DateTime.UtcNow, BatteryTemperature = 25.5, SystemTemperature = 28.3 },
                new TemperatureData { BatteryId = 2, Timestamp = DateTime.UtcNow, BatteryTemperature = 24.8, SystemTemperature = 27.7 }
            );

            modelBuilder.Entity<BatteryCurrent>().HasData(
                new BatteryCurrent { BatteryId = 1, Timestamp = DateTime.UtcNow, CurrentIn = 1.2, CurrentOut = 0.8 },
                new BatteryCurrent { BatteryId = 2, Timestamp = DateTime.UtcNow, CurrentIn = 1.0, CurrentOut = 0.7 }
            );



        }
    }
}

