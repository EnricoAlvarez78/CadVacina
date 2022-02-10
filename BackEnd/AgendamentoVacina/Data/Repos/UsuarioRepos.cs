using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class UsuarioRepos : IUsuarioRepos
    {
        private readonly Context _context;

        public UsuarioRepos(Context context)
        {
            _context = context;
        }

        public async Task<IList<Usuario>> GetAll()
        {
            IQueryable<Usuario> query = _context.Usuarios.Include("Perfil").Include("Posto");
            return await query.AsNoTracking().ToListAsync();   
        }

        public async Task<Usuario> GetById(int id)
        {
            IQueryable<Usuario> query = _context.Usuarios.Include("Perfil").Include("Posto").Where(x => x.Id.Equals(id));
            return await query.AsNoTracking().FirstOrDefaultAsync();   
        }
        
        public async Task<Usuario> GetByEmail(string email)
        {
            IQueryable<Usuario> query = _context.Usuarios.Include("Perfil").Include("Posto").Where(x => x.Email.Equals(email));
            return await query.AsNoTracking().FirstOrDefaultAsync();   
        }

        public async Task<int> Insert(Usuario obj)
        {
            _context.Usuarios.Add(obj);
            await _context.SaveChangesAsync();
            return obj.Id;
        }

        public async Task<bool> Update(Usuario obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<bool> Delete(int id)
        {
            _context.Usuarios.Remove(await GetById(id));
            return await _context.SaveChangesAsync() != 0;
        }
    }
}