using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassiopeia_be.Business.Interfaces
{
    public interface ICollisionService
    {

        Task<CollisionDTO> GetCollisionAsync(int SatelliteId);

    }
}
