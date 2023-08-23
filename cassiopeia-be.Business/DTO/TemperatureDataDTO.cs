namespace cassiopeia_be.Business.DTO
{
    public class TemperatureDataDTO : BaseDTO
    {
        public DateTime Timestamp { get; set; }
        public double BatteryTemperature { get; set; }
        public double SystemTemperature { get; set; }
        public int SatelliteId { get; set; }
    }

}
