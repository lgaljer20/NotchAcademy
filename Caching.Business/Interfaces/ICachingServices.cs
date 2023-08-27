using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caching.Business.Entites;

namespace Caching.Business.Interfaces
{
    public interface ICachingService
    {
        IEnumerable<CacheSatelliteInfo> GetAll();
    }
}