using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IPerfilRepos
    {
        Task<IList<Perfil>> GetAll();
        Task<Perfil> GetById(int id);
    }
}