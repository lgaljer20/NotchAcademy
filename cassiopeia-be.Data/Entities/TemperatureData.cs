namespace cassiopeia_be.Data.Entities
{
    public class TemperatureData : BaseEntity
    {
        public DateTime Timestamp { get; set; }
        public double BatteryTemperature { get; set; }
        public double SystemTemperature { get; set; }
    }

}
