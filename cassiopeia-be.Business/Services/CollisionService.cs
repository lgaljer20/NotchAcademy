using cassiopeia_be.Business.DTO;
using cassiopeia_be.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace cassiopeia_be.Business.Services
{
    public class CollisionService : GenericService<Collision>, ICollisionService
    {

        public CollisionService(CassiopeiaContext context) : base(context)
        { }
        
        public async Task<IEnumerable<CollisionDTO>> GetAllAsync()
        {
            var collisions = await _context.Collisions.select(x => new CollisionDTO
            {
                Id = x.Id,
                Name = x.Name,
                Coordinates = x.Coordinates,
                Velocity = x.Velocity,
                Acceleration = x.Acceleration

            }).ToListAsync;
           
            return collisions;
        }

   



    }
}
