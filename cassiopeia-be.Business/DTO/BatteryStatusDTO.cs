namespace cassiopeia_be.Business.DTO
{
    public class BatteryStatusDTO : BaseDTO
    {
        public double Voltage { get; set; }
        public double Current { get; set; }
        public int ChargeLevel { get; set; }
        public int SatelliteId { get; set; }
    }
}
