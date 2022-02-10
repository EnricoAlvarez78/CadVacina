using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class PerfilRepos : IPerfilRepos
    {
        private readonly Context _context;

        public PerfilRepos(Context context)
        {
            _context = context;
        }

        public async Task<IList<Perfil>> GetAll()
        {
            IQueryable<Perfil> query = _context.Perfils;
            return await query.AsNoTracking().ToListAsync();   
        }

        public async Task<Perfil> GetById(int id)
        {
            return await _context.Perfils.FindAsync(id);
        }
    }
}