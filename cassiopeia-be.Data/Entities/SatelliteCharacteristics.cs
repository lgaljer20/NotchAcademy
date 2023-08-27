using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassiopeia_be.Data.Entities
{
    public class SatelliteCharacteristics
    {
        public string Id { get; set; }
        public float Coordinate_x { get; set; }
        public float Coordinate_y { get; set; }
        public float Coordinate_z { get; set; }

        public float Velocity_x { get; set; }
        public float Velocity_y { get; set; }
        public float Velocity_z { get; set; }

        public float Acceleration_x { get; set; }
        public float Acceleration_y { get; set; }
        public float Acceleration_z { get; set; }
        public DateTime Time { get; set; }
        public float? CollisionTime { get; set; }

    }
}
 