using System.ComponentModel.DataAnnotations.Schema;


namespace cassiopeia_be.Data.Entities
{
    public class AprsMessage : BaseEntity
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public string Observer { get; set; }
        public string Station { get; set; }
        public string Source { get; set; }

        [ForeignKey(nameof(Satellite))]
        public int SatelliteId { get; set; }
        public virtual SatelliteInfo Satellite { get; set; }


    }
}
