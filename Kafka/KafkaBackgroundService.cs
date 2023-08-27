using System;
using System.IO;
using System.Threading.Tasks;
using cassiopeia_be;
using cassiopeia_be.Data.Entities;
using cassiopeia_be.Data;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
namespace Kafka
{
    class KafkaBackgroundService
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var kafkaConfig = new ConsumerConfig
            {
                BootstrapServers = "34.159.95.180:9092",
                GroupId = "cassiopeia",
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };
            var optionsBuilder = new DbContextOptionsBuilder<cassiopeiaContext>()
                .UseSqlServer(configuration.GetConnectionString("cassiopeiaDB"));
            using var consumer = new ConsumerBuilder<Ignore, string>(kafkaConfig).Build();
            consumer.Subscribe("cassiopeia-dev2");
            using var dbContext = new cassiopeiaContext(optionsBuilder.Options);
       
                while (true)
                {
                    var consumeResult = consumer.Consume();
                    if (consumeResult.Message != null)
                    {
                        var positionMessage = consumeResult.Message.Value;
                        try
                        {
                            var item = JsonConvert.DeserializeObject<KafkaMessages>(positionMessage);
                            var satelliteCharacteristics = new SatelliteCharacteristics
                            {
                                Id = item.Id,
                                Coordinate_x = (float)item.Coordinates.X,
                                Coordinate_y = (float)item.Coordinates.Y,
                                Coordinate_z = (float)item.Coordinates.Z,
                                Velocity_x = (float)item.Velocity.X,
                                Velocity_y = (float)item.Velocity.Y,
                                Velocity_z = (float)item.Velocity.Z,
                                Acceleration_x = (float)item.Acceleration.X,
                                Acceleration_y = (float)item.Acceleration.Y,
                                Acceleration_z = (float)item.Acceleration.Z,
                                Time = DateTime.UtcNow,
                            };
                            dbContext.SatelliteCharacteristics.Add(satelliteCharacteristics);
                            await dbContext.SaveChangesAsync();
                            Console.WriteLine($"Received message for satellite {item.Id}:");
                            Console.WriteLine($"Coordinates: x={item.Coordinates.X}, y={item.Coordinates.Y}, z={item.Coordinates.Z}");
                            Console.WriteLine($"Velocity: x={item.Velocity.X}, y={item.Velocity.Y}, z={item.Velocity.Z}");
                            Console.WriteLine($"Acceleration: x={item.Acceleration.X}, y={item.Acceleration.Y}, z={item.Acceleration.Z}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error processing message: {ex.Message}");
                            Console.WriteLine($"Message: {positionMessage}");
                        }
                    }
                
            }
        }
    }
}