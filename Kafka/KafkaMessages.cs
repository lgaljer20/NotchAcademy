using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;


public class KafkaMessages
{
    public string Id { get; set; }
    public Coordinates Coordinates { get; set; }
    public Velocity Velocity { get; set; }
    public Acceleration Acceleration { get; set; }
}

public class Coordinates
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}

public class Velocity
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}

public class Acceleration
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}

