namespace cassiopeia_be.Business.DTO
{
    public class BatteryCurrentDTO : BaseDTO
    {
        public DateTime Timestamp { get; set; }
        public double CurrentIn { get; set; }
        public double CurrentOut { get; set; }
        public int SatelliteId { get; set; }
    }
}
