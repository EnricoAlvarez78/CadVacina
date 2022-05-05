using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class LoteRepos : ILoteRepos
    {
        private readonly Context _context;

        public LoteRepos(Context context)
        {
            _context = context;
        }

        public async Task<IList<Lote>> GetAll()
        {
            IQueryable<Lote> query = _context.Lotes.Include("Posto");
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Lote> GetById(int id)
        {
            IQueryable<Lote> query = _context.Lotes.Include("Posto").Where(x => x.Id.Equals(id));
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<int> Insert(Lote obj)
        {
            _context.Lotes.Add(obj);
            await _context.SaveChangesAsync();
            return obj.Id;
        }

        public async Task<bool> Update(Lote obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<bool> Delete(int id)
        {
            _context.Lotes.Remove(await GetById(id));
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<List<Estatistica>> GetUtilizacaoLotes()
        {
            IQueryable<Lote> query = _context.Lotes;

            var ltList = await query.AsNoTracking().ToListAsync();

            if (ltList != null && ltList.Any())
            {
                var result = new List<Estatistica>();

                foreach (var lt in ltList)
                {
                    result.Add(new Estatistica()
                    {
                        Name = lt.Fabricante,
                        Value = lt.DosesAplicadas
                    });
                }
                
                return result;
            }

            return null;
        }
    }
}