namespace cassiopeia_be.Business.DTO
{
    public class AprsMessageDTO : BaseDTO
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public string Observer { get; set; }
        public string Station { get; set; }
        public string Source { get; set; }
        public int SatelliteId { get; set; }
    }
}
