using Confluent.Kafka;
using Newtonsoft.Json.Linq;
using System;

namespace Kafka
{
    public class KafkaConsumerService
    {
        private readonly IConsumer<Ignore, string> _consumer;

        var string bootstrapServers = "34.159.95.180:9092";
        var string groupId = "cassiopeia";

        public KafkaConsumerService(string bootstrapServers, string groupId, string topic)
        {
            var kafkaConfig = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };

            _consumer = new ConsumerBuilder<Ignore, string>(kafkaConfig).Build();
            _consumer.Subscribe(topic);
        }

        public void ConsumeMessages()
        {
            while (true)
            {
                var consumeResult = _consumer.Consume();

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

        public void Dispose()
        {
            _consumer?.Dispose();
        }
    }
}
