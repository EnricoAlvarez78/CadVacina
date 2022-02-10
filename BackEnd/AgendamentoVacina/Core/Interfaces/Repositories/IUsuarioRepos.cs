using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUsuarioRepos
    {
        Task<IList<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<Usuario> GetByEmail(string email);     
        Task<int> Insert(Usuario obj);
        Task<bool> Update(Usuario obj);
        Task<bool> Delete(int id);     
    }
}