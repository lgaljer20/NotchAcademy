using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassiopeia_be.Data.Entities
{
    public class Thruster : BaseEntity
    {

        public string KeyInterval { get; set; }
     
        private DateTime _time;

        public DateTime Time
        {
            get
            { 
                _time = DateTime.UtcNow;
               
                return _time;
            }
            set
            {
                _time = value;
            }
        }

        private float _FuelLevel;
        public float FuelLevel
        {
            get { return _FuelLevel; }
            set
            {
                if (value < 0)
                {
                    _FuelLevel = 0;
                }
                else if (value > 100)
                {
                    _FuelLevel = 100;
                }
                else
                {
                    _FuelLevel = value;
                }
            }
        }

        [ForeignKey(nameof(Satellite))]
        public string SatelliteId { get; set; }
        public virtual SatelliteCharacteristics Satellite { get; set; }
    }
}
