using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IPerfilServ
    {
        Task<IList<Perfil>> GetAll();
        Task<Perfil> GetById(int id);
    }
}