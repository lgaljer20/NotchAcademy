using cassiopeia_be.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassiopeia_be.Business.DTO
{

    public class CreateEditThrusterDTO
    {
        public string KeyInterval { get; set; }
        public DateTime Time { get; set; }
        public float FuelLevel { get; set; }
        public string SatelliteId { get; set; }
    }
    public class ThrusterDTO : BaseDTO
    {
        public string KeyInterval { get; set;}
        public DateTime Time{ get; set; }
        public float FuelLevel{ get; set; }
        public string SatelliteId { get; set; }
    }
}
