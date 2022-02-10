using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class EnderecoRepos : IEnderecoRepos
    {
        private readonly Context _context;

        public EnderecoRepos(Context context)
        {
            _context = context;
        }

        public async Task<IList<Endereco>> GetAll()
        {
            IQueryable<Endereco> query = _context.Enderecos;
            return await query.AsNoTracking().ToListAsync();   
        }

        public async Task<Endereco> GetById(int id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task<int> Insert(Endereco obj)
        {
            _context.Enderecos.Add(obj);
            await _context.SaveChangesAsync();
            return obj.Id;
        }

        public async Task<bool> Update(Endereco obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<bool> Delete(int id)
        {
            _context.Enderecos.Remove(await GetById(id));
            return await _context.SaveChangesAsync() != 0;
        }
    }
}