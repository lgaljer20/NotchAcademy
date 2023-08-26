using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caching.Business.Entities;
using Caching.Business.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.Business.Services
{
    public class CachingService : ICachingService
    {

        private readonly DataContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public CachingService(DataContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            this._memoryCache = memoryCache;
        }

        public IEnumerable<SatelliteInfo> GetAll()
        {
            string key = "SatelliteInfo";

            if (!_memoryCache.TryGetValue(key, out IEnumerable<SatelliteInfo> satellites))
            {
                satellites = _dbContext.Set<SatelliteInfo>().ToList();
                
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                
                _memoryCache.Set(key, satellites, cacheOptions);
            }

            services.AddMemoryCache();

            return _dbContext.SatelliteInfo.ToList();
        }

    }
}
