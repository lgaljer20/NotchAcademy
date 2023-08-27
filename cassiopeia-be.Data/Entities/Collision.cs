using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassiopeia_be.Data.Entities
{
    public class Collision : BaseEntity
    {

        public int Id { get; set; }
        public float Coordinates { get; set; }
        public float Velocity { get; set; }
        public float Acceleration { get; set; }


    }
}
