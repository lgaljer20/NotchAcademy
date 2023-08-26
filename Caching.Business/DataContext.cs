using Caching.Business.Entities;
using Caching.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;

namespace Caching.Business
{
    public class DataContext : DbContext
    {

        public DbSet<SatelliteInfo> SatelliteInfo { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(XmlSchemaContentModel model)
        {
            model.Entity<SatelliteInfo>().HasData(
                new SatelliteInfo { id = 1, 
                                    Name = "Satellite 1", 
                                    Description = "Satellite 1 Description" },
                new SatelliteInfo { id = 2, 
                                    Name = "Satellite 2", 
                                    Description = "Satellite 2 Description" }
                );
        }

    }
}