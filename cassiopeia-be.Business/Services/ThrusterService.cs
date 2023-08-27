using cassiopeia_be.Business.DTO;
using cassiopeia_be.Data;
using cassiopeia_be.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassiopeia_be.Business.Services
{
    public class ThrusterService
    {
        protected readonly CassiopeiaContext _context;
        private readonly SatelliteCharacteristicsService _satelliteService;
        public ThrusterService(CassiopeiaContext context, SatelliteCharacteristicsService satelliteService)
        {
            _context = context;
            _satelliteService = satelliteService;
        }

        public async Task<IEnumerable<ThrusterDTO>> GetThrustersBySatelliteId(string satelliteId) //uvijek saljite cassiopeia
        {
            var list = await _context.ThrusterData
                .Where(thruster => thruster.SatelliteId == satelliteId)
                .Select(thruster => new ThrusterDTO
                {
                    Time = thruster.Time,
                    FuelLevel = thruster.FuelLevel,
                    Id = thruster.Id,
                    SatelliteId = thruster.SatelliteId

                })
                .ToListAsync();

            foreach (var thruster in list)
            {
                thruster.KeyInterval = calculateKeyInterval(thruster.FuelLevel);
            }

            return list;
        }

        private string calculateKeyInterval(float fuelLevel)
        {
            string[] fuelKey = { "Empty", "Quarter", "Half", "Three Quarters", "Full" };

            if (fuelLevel >= 1 && fuelLevel <= 24)
                return fuelKey[1];
            else if (fuelLevel >= 25 && fuelLevel <= 49)
                return fuelKey[2];
            else if (fuelLevel >= 50 && fuelLevel <= 74)
                return fuelKey[3];
            else if (fuelLevel >= 75 && fuelLevel <= 100)
                return fuelKey[4];
            else
                return fuelKey[0];
        }

        public async Task UpdateFuelLevel(float c_x, float c_y, float c_z, float v)
        {
            var cassiopeiaSatellite = await _context.SatelliteCharacteristics.FirstOrDefaultAsync(s => s.Id == "cassiopeia");

            if (cassiopeiaSatellite == null)
            {
                return;
            }

            float deltaX = cassiopeiaSatellite.Coordinate_x - c_x;
            float deltaY = cassiopeiaSatellite.Coordinate_y - c_y;
            float deltaZ = cassiopeiaSatellite.Coordinate_z - c_z;

            var thrusters = await GetThrustersBySatelliteId("cassiopeia");
            var thrusterList = thrusters.ToList();

            float newFuelLevel;

    
            if (deltaX < 0)
            {
                newFuelLevel = thrusterList[0].FuelLevel - Math.Abs(deltaX);
                CheckFuelLevel(newFuelLevel);
                thrusterList[0].FuelLevel = newFuelLevel;
            }
            else
            {
                newFuelLevel = thrusterList[1].FuelLevel - Math.Abs(deltaX);
                CheckFuelLevel(newFuelLevel);
                thrusterList[1].FuelLevel = newFuelLevel;
            }

  
            if (deltaY < 0)
            {
                newFuelLevel = thrusterList[2].FuelLevel - Math.Abs(deltaY);
                CheckFuelLevel(newFuelLevel);
                thrusterList[2].FuelLevel = newFuelLevel;
            }
            else
            {
                newFuelLevel = thrusterList[3].FuelLevel - Math.Abs(deltaY);
                CheckFuelLevel(newFuelLevel);
                thrusterList[3].FuelLevel = newFuelLevel;
            }

      
            if (deltaZ < 0)
            {
                newFuelLevel = thrusterList[4].FuelLevel - Math.Abs(deltaZ);
                CheckFuelLevel(newFuelLevel);
                thrusterList[4].FuelLevel = newFuelLevel;
            }
            else
            {
                newFuelLevel = thrusterList[5].FuelLevel - Math.Abs(deltaZ);
                CheckFuelLevel(newFuelLevel);
                thrusterList[5].FuelLevel = newFuelLevel;
            }

            await _satelliteService.UpdateManualPositionAndVelocityAsync(c_x, c_y, c_z, v);

            await SaveThrusterChanges(thrusterList);
        }

        private void CheckFuelLevel(float fuelLevel)
        {
            if (fuelLevel < 0)
            {
                throw new InvalidOperationException("Fuel Level cannot be negative.");
            }
        }
        public async Task SaveThrusterChanges(List<ThrusterDTO> thrusterList)
        {
            foreach (var thrusterDTO in thrusterList)
            {
      
                var existingEntity = await _context.ThrusterData.FirstOrDefaultAsync(t => t.Id == thrusterDTO.Id);

                if (existingEntity != null)
                {
                    existingEntity.FuelLevel = thrusterDTO.FuelLevel;
                    existingEntity.Time = thrusterDTO.Time;
                    _context.Entry(existingEntity).State = EntityState.Modified;
                }
            }
            await _context.SaveChangesAsync();
        }



    }
}
