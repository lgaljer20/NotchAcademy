﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cassiopeia_be.Data;

#nullable disable

namespace cassiopeia_be.Data.Migrations
{
    [DbContext(typeof(CassiopeiaContext))]
    partial class CassiopeiaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cassiopeia_be.Data.Entities.AprsMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SatelliteId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Station")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SatelliteId");

                    b.ToTable("AprsMessages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Message = "Hello from CubeSat-1!",
                            Observer = "Ground Station A",
                            SatelliteId = 1,
                            Source = "NOCALL",
                            Station = "CubeSat-1",
                            Time = new DateTime(2023, 8, 21, 12, 43, 29, 596, DateTimeKind.Local).AddTicks(7159)
                        },
                        new
                        {
                            Id = 2,
                            Message = "Temperature: 25°C, Battery: 85%",
                            Observer = "Ground Station B",
                            SatelliteId = 1,
                            Source = "NOCALL",
                            Station = "CubeSat-2",
                            Time = new DateTime(2023, 8, 21, 12, 43, 29, 596, DateTimeKind.Local).AddTicks(7171)
                        },
                        new
                        {
                            Id = 3,
                            Message = "Deployed solar panels successfully!",
                            Observer = "Ground Station C",
                            SatelliteId = 1,
                            Source = "NOCALL",
                            Station = "CubeSat-3",
                            Time = new DateTime(2023, 8, 21, 12, 43, 29, 596, DateTimeKind.Local).AddTicks(7173)
                        },
                        new
                        {
                            Id = 4,
                            Message = "Orbit update: Altitude: 400 km, Inclination: 45°",
                            Observer = "Ground Station D",
                            SatelliteId = 1,
                            Source = "NOCALL",
                            Station = "CubeSat-4",
                            Time = new DateTime(2023, 8, 21, 12, 43, 29, 596, DateTimeKind.Local).AddTicks(7175)
                        },
                        new
                        {
                            Id = 5,
                            Message = "Experiment results: Successful microgravity test.",
                            Observer = "Ground Station E",
                            SatelliteId = 1,
                            Source = "NOCALL",
                            Station = "CubeSat-5",
                            Time = new DateTime(2023, 8, 21, 12, 43, 29, 596, DateTimeKind.Local).AddTicks(7177)
                        });
                });

            modelBuilder.Entity("cassiopeia_be.Data.Entities.SatelliteInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("APRSIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("BatteryCapacityIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("BatteryTemperatureIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("BatteryVoltageIsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LaunchDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OBC9DOTemperatureIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("OBCFreeMemoryIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("OBCMCUTemperatureIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("OBCNumberIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("OBCPacketRecordIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("OBCRestartIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("OBCTimestampIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("OBCUptimeTotalIsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("OriginCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ReceivedByIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("SignalCountIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("SolarTemperatureIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("StatusIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("UHFTemperatureIsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("VHFTemperatureIsEnabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("SatelliteInfos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            APRSIsEnabled = true,
                            BatteryCapacityIsEnabled = true,
                            BatteryTemperatureIsEnabled = true,
                            BatteryVoltageIsEnabled = true,
                            Image = "https://some_random_image.jpg",
                            LaunchDate = new DateTime(2023, 8, 7, 17, 45, 0, 0, DateTimeKind.Local),
                            Name = "cassiopeia",
                            OBC9DOTemperatureIsEnabled = true,
                            OBCFreeMemoryIsEnabled = true,
                            OBCMCUTemperatureIsEnabled = true,
                            OBCNumberIsEnabled = true,
                            OBCPacketRecordIsEnabled = true,
                            OBCRestartIsEnabled = true,
                            OBCTimestampIsEnabled = true,
                            OBCUptimeTotalIsEnabled = true,
                            OriginCountry = "Croatia",
                            Owner = "notch",
                            ReceivedByIsEnabled = true,
                            SignalCountIsEnabled = true,
                            SolarTemperatureIsEnabled = true,
                            StatusIsEnabled = true,
                            UHFTemperatureIsEnabled = true,
                            VHFTemperatureIsEnabled = true
                        });
                });

            modelBuilder.Entity("cassiopeia_be.Data.Entities.AprsMessage", b =>
                {
                    b.HasOne("cassiopeia_be.Data.Entities.SatelliteInfo", "Satellite")
                        .WithMany()
                        .HasForeignKey("SatelliteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Satellite");
                });
#pragma warning restore 612, 618
        }
    }
}
