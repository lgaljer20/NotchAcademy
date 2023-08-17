using cassiopeia_be.Business.DTO;
using cassiopeia_be.Data;
using Microsoft.EntityFrameworkCore;

namespace cassiopeia_be.Business.Services
{
    public class AprsMessageService
    {
        protected readonly CassiopeiaContext _context;
        public AprsMessageService(CassiopeiaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AprsMessageDTO>> GetAprsMessagesBySatelliteId(int satelliteId)
        {
            var list = await _context.AprsMessages
                .Where(aprs => aprs.SatelliteId == satelliteId)
                .Select(aprs => new AprsMessageDTO
                {
                    Time = aprs.Time,
                    Message = aprs.Message,
                    Observer = aprs.Observer,
                    Station = aprs.Station,
                    Source = aprs.Source
                    
                })
                .ToListAsync();

            return list;
        }
    }
}
