namespace cassiopeia_be.Business.DTO
{
    public class SatelliteDataDTO
    {
        public DateTime Timestamp { get; set; }
        public string SatelliteId { get; set; }
        public BatteryStatusDTO BatteryStatus { get; set; }
        public SolarPanelsDTO SolarPanels { get; set; }
        public PowerConsumptionDTO PowerConsumption { get; set; }
        public bool OvercurrentProtection { get; set; }
        public string SystemStatus { get; set; }
    }
}
