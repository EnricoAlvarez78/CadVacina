using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class AgendaRepos : IAgendaRepos
    {
        private readonly Context _context;

        public AgendaRepos(Context context)
        {
            _context = context;
        }
        
        public async Task<int> Insert(Agenda agenda)
        {
            _context.Agenda.Add(agenda);
            await _context.SaveChangesAsync();
            return agenda.Id; 
        }

        public async Task<bool> Update(Agenda agenda)
        {
            _context.Entry(agenda).State = EntityState.Modified;
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<bool> Delete(int id)
        {            
            _context.Agenda.Remove(await GetById(id));
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<IList<Agenda>> GetAll()
        {
            IQueryable<Agenda> query = _context.Agenda.Include("Lote").Include("Posto");
            return await query.AsNoTracking().ToListAsync();            
        }

        public async Task<Agenda> GetById(int id)
        {
            IQueryable<Agenda> query = _context.Agenda.Where(x => x.Id.Equals(id));
            return await query.AsNoTracking().FirstOrDefaultAsync();    
        }

    }
}