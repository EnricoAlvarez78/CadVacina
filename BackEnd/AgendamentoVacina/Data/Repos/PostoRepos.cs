using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class PostoRepos : IPostoRepos
    {
        private readonly Context _context;

        public PostoRepos(Context context)
        {
            _context = context;
        }

        public async Task<IList<Posto>> GetAll()
        {
            IQueryable<Posto> query = _context.Postos.Include("Endereco").Include("Lotes");
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Posto> GetById(int id)
        {
            IQueryable<Posto> query = _context.Postos.Where(x => x.Id.Equals(id)).Include("Endereco");
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<int> Insert(Posto obj)
        {
            _context.Postos.Add(obj);
            await _context.SaveChangesAsync();
            return obj.Id;
        }

        public async Task<bool> Update(Posto obj)
        {
            var end = await _context.Enderecos.FindAsync(obj.IdEndereco);
            end.Cidade = obj.Endereco.Cidade;
            end.Cep = obj.Endereco.Cep;
            end.Bairro = obj.Endereco.Bairro;
            end.Numero = obj.Endereco.Numero;
            end.Rua = obj.Endereco.Rua;

            _context.Entry(end).State = EntityState.Modified;
            _context.Entry(obj).State = EntityState.Modified;

            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<bool> Delete(int id)
        {
            var posto = await _context.Postos.Where(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
            var end = await _context.Enderecos.Where(x => x.Id.Equals(posto.IdEndereco)).AsNoTracking().FirstOrDefaultAsync();

            _context.Postos.Remove(posto);
            _context.Enderecos.Remove(end);

            return await _context.SaveChangesAsync() != 0;
        }
    }
}