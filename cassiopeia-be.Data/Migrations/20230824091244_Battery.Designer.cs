﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cassiopeia_be.Data;

#nullable disable

namespace cassiopeia_be.Data.Migrations
{
    [DbContext(typeof(CassiopeiaContext))]
    [Migration("20230824091244_Battery")]
    partial class Battery
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Battery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SatelliteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SatelliteId");

                    b.ToTable("Battery");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SatelliteId = 1
                        },
                        new
                        {
                            Id = 2,
                            SatelliteId = 1
                        });
                });

            modelBuilder.Entity("BatteryCurrent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BatteryId")
                        .HasColumnType("int");

                    b.Property<double>("CurrentIn")
                        .HasColumnType("float");

                    b.Property<double>("CurrentOut")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BatteryId");

                    b.ToTable("BatteryCurrentRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BatteryId = 1,
                            CurrentIn = 1.2,
                            CurrentOut = 0.80000000000000004,
                            Timestamp = new DateTime(2023, 8, 24, 9, 12, 44, 801, DateTimeKind.Utc).AddTicks(3212)
                        },
                        new
                        {
                            Id = 2,
                            BatteryId = 2,
                            CurrentIn = 1.0,
                            CurrentOut = 0.69999999999999996,
                            Timestamp = new DateTime(2023, 8, 24, 9, 12, 44, 801, DateTimeKind.Utc).AddTicks(3214)
                        });
                });

            modelBuilder.Entity("BatteryStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BatteryId")
                        .HasColumnType("int");

                    b.Property<int>("ChargeLevel")
                        .HasColumnType("int");

                    b.Property<double>("Current")
                        .HasColumnType("float");

                    b.Property<double>("Voltage")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BatteryId");

                    b.ToTable("BatteryStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BatteryId = 1,
                            ChargeLevel = 80,
                            Current = 5.0,
                            Voltage = 12.5
                        },
                        new
                        {
                            Id = 2,
                            BatteryId = 2,
                            ChargeLevel = 75,
                            Current = 4.7999999999999998,
                            Voltage = 13.199999999999999
                        });
                });

            modelBuilder.Entity("TemperatureData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BatteryId")
                        .HasColumnType("int");

                    b.Property<double>("BatteryTemperature")
                        .HasColumnType("float");

                    b.Property<double>("SystemTemperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BatteryId");

                    b.ToTable("TemperatureDataRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BatteryId = 1,
                            BatteryTemperature = 25.5,
                            SystemTemperature = 28.300000000000001,
                            Timestamp = new DateTime(2023, 8, 24, 9, 12, 44, 801, DateTimeKind.Utc).AddTicks(3196)
                        },
                        new
                        {
                            Id = 2,
                            BatteryId = 2,
                            BatteryTemperature = 24.800000000000001,
                            SystemTemperature = 27.699999999999999,
                            Timestamp = new DateTime(2023, 8, 24, 9, 12, 44, 801, DateTimeKind.Utc).AddTicks(3198)
                        });
                });

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
                            Time = new DateTime(2023, 8, 24, 11, 12, 44, 800, DateTimeKind.Local).AddTicks(6520)
                        },
                        new
                        {
                            Id = 2,
                            Message = "Temperature: 25°C, Battery: 85%",
                            Observer = "Ground Station B",
                            SatelliteId = 1,
                            Source = "NOCALL",
                            Station = "CubeSat-2",
                            Time = new DateTime(2023, 8, 24, 11, 12, 44, 800, DateTimeKind.Local).AddTicks(6544)
                        },
                        new
                        {
                            Id = 3,
                            Message = "Deployed solar panels successfully!",
                            Observer = "Ground Station C",
                            SatelliteId = 1,
                            Source = "NOCALL",
                            Station = "CubeSat-3",
                            Time = new DateTime(2023, 8, 24, 11, 12, 44, 800, DateTimeKind.Local).AddTicks(6547)
                        },
                        new
                        {
                            Id = 4,
                            Message = "Orbit update: Altitude: 400 km, Inclination: 45°",
                            Observer = "Ground Station D",
                            SatelliteId = 1,
                            Source = "NOCALL",
                            Station = "CubeSat-4",
                            Time = new DateTime(2023, 8, 24, 11, 12, 44, 800, DateTimeKind.Local).AddTicks(6549)
                        },
                        new
                        {
                            Id = 5,
                            Message = "Experiment results: Successful microgravity test.",
                            Observer = "Ground Station E",
                            SatelliteId = 1,
                            Source = "NOCALL",
                            Station = "CubeSat-5",
                            Time = new DateTime(2023, 8, 24, 11, 12, 44, 800, DateTimeKind.Local).AddTicks(6552)
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

            modelBuilder.Entity("Battery", b =>
                {
                    b.HasOne("cassiopeia_be.Data.Entities.SatelliteInfo", "SatelliteInfo")
                        .WithMany("Batteries")
                        .HasForeignKey("SatelliteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SatelliteInfo");
                });

            modelBuilder.Entity("BatteryCurrent", b =>
                {
                    b.HasOne("Battery", "Battery")
                        .WithMany("BatteryCurrents")
                        .HasForeignKey("BatteryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Battery");
                });

            modelBuilder.Entity("BatteryStatus", b =>
                {
                    b.HasOne("Battery", "Battery")
                        .WithMany("BatteryStatuses")
                        .HasForeignKey("BatteryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Battery");
                });

            modelBuilder.Entity("TemperatureData", b =>
                {
                    b.HasOne("Battery", "Battery")
                        .WithMany("TemperatureDataRecords")
                        .HasForeignKey("BatteryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Battery");
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

            modelBuilder.Entity("Battery", b =>
                {
                    b.Navigation("BatteryCurrents");

                    b.Navigation("BatteryStatuses");

                    b.Navigation("TemperatureDataRecords");
                });

            modelBuilder.Entity("cassiopeia_be.Data.Entities.SatelliteInfo", b =>
                {
                    b.Navigation("Batteries");
                });
#pragma warning restore 612, 618
        }
    }
}