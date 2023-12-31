
using cassiopeia_be.Business.DTO;
using cassiopeia_be.Data;
using cassiopeia_be.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cassiopeia_be.Business.Services
{
    public class SatelliteCharacteristicsService
    {
        public List<SatelliteCharacteristicsDTO> CollisionSatellites = new List<SatelliteCharacteristicsDTO>();

        public List<SatelliteCharacteristicsDTO> GoodSatellites = new List<SatelliteCharacteristicsDTO>();

        private bool collision_position;
        private bool collision_velocity;
        private float coo_x_diff;
        private float coo_y_diff;
        private float coo_z_diff;
        private float vel_x_diff;
        private float vel_y_diff;
        private float vel_z_diff;
        private float acc_x_diff;
        private float acc_y_diff;
        private float acc_z_diff;

        protected readonly CassiopeiaContext _context;
        public SatelliteCharacteristicsService(CassiopeiaContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(JArray jsonArray)
        {
            List<CreateEditSatelliteCharacteristicsDTO> satellites = jsonArray.ToObject<List<CreateEditSatelliteCharacteristicsDTO>>();


            var existingIds = new HashSet<string>(await _context.SatelliteCharacteristics
                                                    .Select(s => s.Id)
                                                    .ToListAsync());

            List<SatelliteCharacteristics> entitiesToAdd = new List<SatelliteCharacteristics>();

            foreach (var satellite in satellites)
            {
                if (!existingIds.Contains(satellite.Id))
                {
                    var entity = new SatelliteCharacteristics
                    {
                        Id = satellite.Id,
                        Time = DateTime.Now,
                        Coordinate_x = satellite.Coordinate_x,
                        Coordinate_y = satellite.Coordinate_y,
                        Coordinate_z = satellite.Coordinate_z,
                        Acceleration_x = satellite.Acceleration_x,
                        Acceleration_y = satellite.Acceleration_y,
                        Acceleration_z = satellite.Acceleration_z,
                        Velocity_x = satellite.Velocity_x,
                        Velocity_y = satellite.Velocity_y,
                        Velocity_z = satellite.Velocity_z
                    };
                    entitiesToAdd.Add(entity);
                }
            }

            await _context.SatelliteCharacteristics.AddRangeAsync(entitiesToAdd);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<IEnumerable<SatelliteCharacteristicsDTO>> GetAllAsync()
        {
            var list = await _context.SatelliteCharacteristics.Select(s => new SatelliteCharacteristicsDTO
            {
                Id = s.Id,
                Coordinate_x = s.Coordinate_x,
                Coordinate_y = s.Coordinate_y,
                Coordinate_z = s.Coordinate_z,
                Velocity_x = s.Velocity_x,
                Velocity_y = s.Velocity_y,
                Velocity_z = s.Velocity_z,
                Acceleration_x = s.Acceleration_x,
                Acceleration_y = s.Acceleration_y,
                Acceleration_z = s.Acceleration_z,
                Time = s.Time
            }).ToListAsync();

            return list;
        }

        public bool signum(double a, double b)
        {
            return (a * b) > 0;
        }

        public DateTime GetLastTime(SatelliteCharacteristicsDTO satellite)
        {
            return satellite.Time;
        }

        public SatelliteCharacteristicsDTO NewPosition(SatelliteCharacteristicsDTO satellite)
        {
            DateTime oldTime = GetLastTime(satellite);
            TimeSpan duration = DateTime.Now - oldTime;

            double seconds = duration.TotalSeconds;

            satellite.Coordinate_x = (float)(satellite.Coordinate_x + seconds * satellite.Velocity_x);
            satellite.Coordinate_y = (float)(satellite.Coordinate_y + seconds * satellite.Velocity_y);
            satellite.Coordinate_z = (float)(satellite.Coordinate_z + seconds * satellite.Velocity_z);

            return satellite;

        }
        public async Task<(List<SatelliteCharacteristicsDTO> CollisionSatellites , List<SatelliteCharacteristicsDTO> GoodSatellites)> CheckForCollision()
        
            {
            var allSatellites = await GetAllAsync();
            foreach (var sat in allSatellites)
            {
                Console.WriteLine($"ID: {sat.Id}, X: {sat.Coordinate_x}, ...");
            }
            List<SatelliteCharacteristicsDTO> list = allSatellites.ToList();


            SatelliteCharacteristicsDTO cassiopeiaSatellite = list.FirstOrDefault(s => s.Id == "cassiopeia");

            NewPosition(cassiopeiaSatellite);

                foreach (var satellite in list)
                {
                if (satellite.Id == "cassiopeia")
                {
                    continue;
                }

                NewPosition(satellite);

                if (signum(cassiopeiaSatellite.Coordinate_x, satellite.Coordinate_x) &&
                    signum(cassiopeiaSatellite.Coordinate_y, satellite.Coordinate_y) &&
                    signum(cassiopeiaSatellite.Coordinate_z, satellite.Coordinate_z)
                )

                {
                    collision_position = true;
                }

                if (signum(cassiopeiaSatellite.Velocity_x, satellite.Velocity_x) &&
             signum(cassiopeiaSatellite.Velocity_y, satellite.Velocity_y) &&
                signum(cassiopeiaSatellite.Velocity_z, satellite.Velocity_z)
                )
                { 
                    collision_velocity = true;
                }
           


                if (!collision_position || !collision_velocity)
                {
                   GoodSatellites.Add(satellite);
                }
                else
                {
                    coo_x_diff = Math.Abs((cassiopeiaSatellite.Coordinate_x - satellite.Coordinate_x));
                    coo_y_diff = Math.Abs((cassiopeiaSatellite.Coordinate_y - satellite.Coordinate_y));
                    coo_z_diff = Math.Abs((cassiopeiaSatellite.Coordinate_z - satellite.Coordinate_z));

                    vel_x_diff = Math.Abs((cassiopeiaSatellite.Velocity_x - satellite.Velocity_x));
                    vel_y_diff = Math.Abs((cassiopeiaSatellite.Velocity_y - satellite.Velocity_y));
                    vel_z_diff = Math.Abs((cassiopeiaSatellite.Velocity_z - satellite.Velocity_z));

                    acc_x_diff = Math.Abs((cassiopeiaSatellite.Acceleration_x - satellite.Acceleration_x));
                    acc_y_diff = Math.Abs((cassiopeiaSatellite.Acceleration_y - satellite.Acceleration_y));
                    acc_z_diff = Math.Abs((cassiopeiaSatellite.Acceleration_z - satellite.Acceleration_z));

                    double[] calculations = new double[6];
                    double[] collisions = new double[6];
                    calculations[0] = (-(vel_x_diff) + Math.Sqrt(4 * (acc_x_diff) * (coo_x_diff) - Math.Pow(vel_x_diff,2)));
                    calculations[1] = (-(vel_x_diff) - Math.Sqrt(4 * (acc_x_diff) * (coo_x_diff) - Math.Pow(vel_x_diff,2)));
                    calculations[2] = (-(vel_y_diff) + Math.Sqrt(4 * (acc_y_diff) * (coo_y_diff) - Math.Pow(vel_y_diff,2)));
                    calculations[3] = (-(vel_y_diff) - Math.Sqrt(4 * (acc_y_diff) * (coo_y_diff) - Math.Pow(vel_y_diff,2)));
                    calculations[4] = (-(vel_z_diff) + Math.Sqrt(4 * (acc_z_diff) * (coo_z_diff) - Math.Pow(vel_z_diff,2)));
                    calculations[5] = (-(vel_z_diff) - Math.Sqrt(4 * (acc_z_diff) * (coo_z_diff) - Math.Pow(vel_z_diff,2)));

                    for (int i = 0; i <6; i++)
                    {
                        int j = 0;
                        if (calculations[i] > 0)
                        {

                            collisions[j] = calculations[i];
                            j++;

                        }
                    }
                    if (collisions.Any(x => x > 0))  // If kolizija has any positive value
                    {
                        satellite.CollisionTime = collisions.Where(x => x > 0).Min();
                        CollisionSatellites.Add(satellite);
                    }

                }

            }
            if (CollisionSatellites != null)
            {
                CollisionSatellites = CollisionSatellites.OrderBy(s => s.CollisionTime).ToList();
            }

  
            return (CollisionSatellites, GoodSatellites);


        }

        public async Task UpdateManualPositionAndVelocityAsync(float c_x, float c_y, float c_z, float v)
        {
            var cassiopeiaSatellite = _context.SatelliteCharacteristics.FirstOrDefault(s => s.Id == "cassiopeia");

            if (cassiopeiaSatellite == null)
            {
              
                return;
            }

            float v_x_ms = v * (1000f / 3600f);
            float v_y_ms = v * (1000f / 3600f);
            float v_z_ms = v * (1000f / 3600f);

            cassiopeiaSatellite.Coordinate_x = c_x;
            cassiopeiaSatellite.Coordinate_y = c_y;
            cassiopeiaSatellite.Coordinate_z = c_z;

            cassiopeiaSatellite.Velocity_x = v_x_ms;
            cassiopeiaSatellite.Velocity_y = v_y_ms;
            cassiopeiaSatellite.Velocity_z = v_z_ms;


            await _context.SaveChangesAsync();
        }

       


    }

}