using Confluent.Kafka;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Kafka
{
    class Characteristics
    {
        static async Task Main(string[] args)
        {
            var kafkaConfig = new ConsumerConfig
            {
                BootstrapServers = "34.159.95.180:9092",
                GroupId = "cassiopeia",
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(kafkaConfig).Build();

            consumer.Subscribe("cassiopeia-dev2");

            while (true)
            {
                var consumeResult = consumer.Consume();

                if (consumeResult.Message != null)
                {
                    var positionMessage = consumeResult.Message.Value;

                    try
                    {
                        var jsonArray = JArray.Parse(positionMessage);

                        foreach (var item in jsonArray)
                        {
                            var satelliteId = item["id"].ToString();
                            var coordinates = item["coordinates"];
                            var velocity = item["velocity"];
                            var acceleration = item["acceleration"];

                            Console.WriteLine($"Received message for satellite {satelliteId}:");
                            Console.WriteLine($"Coordinates: x={coordinates["x"]}, y={coordinates["y"]}, z={coordinates["z"]}");
                            Console.WriteLine($"Velocity: x={velocity["x"]}, y={velocity["y"]}, z={velocity["z"]}");
                            Console.WriteLine($"Acceleration: x={acceleration["x"]}, y={acceleration["y"]}, z={acceleration["z"]}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing message: {ex.Message}");
                    }
                }
            }
        }
    }
}
