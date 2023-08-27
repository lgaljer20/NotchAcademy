using Confluent.Kafka;
using Newtonsoft.Json;

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

            consumer.Subscribe("cassiopeia-dev3");

            while (true)
            {
                var consumeResult = consumer.Consume();

                if (consumeResult.Message != null)
                {
                    var positionMessage = consumeResult.Message.Value;

                    try
                    {
                        var item = JsonConvert.DeserializeObject<KafkaMessages>(positionMessage);

                        Console.WriteLine($"Received message for satellite {item.Id}:");
                        Console.WriteLine($"Coordinates: x={item.Coordinates.X}, y={item.Coordinates.Y}, z={item.Coordinates.Z}");
                        Console.WriteLine($"Velocity: x={item.Velocity.X}, y={item.Velocity.Y}, z={item.Velocity.Z}");
                        Console.WriteLine($"Acceleration: x={item.Acceleration.X}, y={item.Acceleration.Y}, z={item.Acceleration.Z}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deserializing message: {ex.Message}");
                    }
                }
            }
        }
    }
}

