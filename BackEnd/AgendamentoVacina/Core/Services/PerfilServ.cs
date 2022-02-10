using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class PerfilServ : IPerfilServ
    {
        private readonly IPerfilRepos _perfilRepos;

        public PerfilServ(IPerfilRepos perfilRepos) => _perfilRepos = perfilRepos;

        public async Task<IList<Perfil>> GetAll()
        {
            return await _perfilRepos.GetAll();
        }

        public async Task<Perfil> GetById(int id)
        {
            return await _perfilRepos.GetById(id);
        } 
    }
}