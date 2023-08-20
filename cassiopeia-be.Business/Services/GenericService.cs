using cassiopeia_be.Data;
using cassiopeia_be.Data.Entities;
using cassiopeia_be.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cassiopeia_be.Business.Services
{
    public class GenericService<TEntity> : IService
        where TEntity : BaseEntity
    {
        protected readonly CassiopeiaContext _context;

        public GenericService(CassiopeiaContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {

            await _context.Set<TEntity>().Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}

