using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassiopeia_be.Data.Entities
{
    public class SatelliteInfo :BaseEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime LaunchDate { get; set; }
        public string Status { get; set; }
        public string Owner { get; set; }
        public string OriginCountry { get; set; }
    }
}
