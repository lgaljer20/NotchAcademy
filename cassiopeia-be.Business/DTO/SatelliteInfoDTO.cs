namespace cassiopeia_be.Business.DTO
{
    public class SatelliteInfoDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime LaunchDate { get; set; }
        public string Status { get; set; }
        public string Owner { get; set; }
        public string OriginCountry { get; set; }
    }
}
