using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class GrupoRepos : IGrupoRepos
    {
        private readonly Context _context;

        public GrupoRepos(Context context)
        {
            _context = context;
        }

        public async Task<IList<Grupo>> GetAll()
        {
            IQueryable<Grupo> query = _context.Grupos;
            return await query.AsNoTracking().ToListAsync();   
        }

        public async Task<Grupo> GetById(int id)
        {
            IQueryable<Grupo> query = _context.Grupos.Where(x => x.Id.Equals(id));
            return await query.AsNoTracking().FirstOrDefaultAsync();  
        }

        public async Task<int> Insert(Grupo obj)
        {
            _context.Grupos.Add(obj);
            await _context.SaveChangesAsync();
            return obj.Id;
        }

        public async Task<bool> Update(Grupo obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified ;
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<bool> Delete(int id)
        {
            _context.Grupos.Remove(await GetById(id));
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<IList<Grupo>> GetListByAge(int age)
        {
            IQueryable<Grupo> query = _context.Grupos.Where(x => x.IdadeMinima <= age && x.Ativo);
            return await query.AsNoTracking().ToListAsync();   
        }
    }
}