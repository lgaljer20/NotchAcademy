using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching.Business.Entites
{
    public class CacheSatelliteInfo
    {


        public string Id { get; set; }
        public Coordinates Coordinates { get; set; }
        public Velocity Velocity { get; set; }
        public Acceleration Acceleration { get; set; }

    }

    public class Coordinates
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public class Velocity
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public class Acceleration
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

}
