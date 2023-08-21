namespace cassiopeia_be.Data.Entities
{
    public class SatelliteInfo :BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime LaunchDate { get; set; }
        public bool Status { get; set; }
        public string Owner { get; set; }
        public string OriginCountry { get; set; }
    }
}

