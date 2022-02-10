using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class PostoServ : IPostoServ
    {
        private readonly IPostoRepos _postoRepos;

        public PostoServ(IPostoRepos postoRepos) => _postoRepos = postoRepos;

        public async Task<IList<Posto>> GetAll()
        {
            return await _postoRepos.GetAll();
        }

        public async Task<IList<Posto>> GetListAvailable()
        {
            return await GetAvailables();
        }

        public async Task<Posto> GetById(int id)
        {
            return await _postoRepos.GetById(id);
        }

        public async Task<int> Insert(Posto obj)
        {
            return await _postoRepos.Insert(obj);
        }

        public async Task<bool> Update(Posto obj)
        {
            return await _postoRepos.Update(obj);
        }

        public async Task<bool> Delete(int id)
        {
            return await _postoRepos.Delete(id);
        }  

        private async Task<IList<Posto>> GetAvailables()
        {
            var result = new List<Posto>();
            var lst = await _postoRepos.GetAll();
            if (lst != null && lst.Any())
            {
                lst = lst.Where(x => x.Lotes != null && x.Lotes.Any()).ToList();
                if (lst != null && lst.Any())
                    foreach (var posto in lst)
                        if (posto.Lotes.Where(x => (x.QuantidadeDoses - x.DosesReservadas - x.DosesAplicadas) > 0).Any())
                            result.Add(posto);
            }

            return result;
        }      
    }
}