using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class LoteServ : ILoteServ
    {        
        private readonly ILoteRepos _loteRepos;

        public LoteServ(ILoteRepos loteRepos) => _loteRepos = loteRepos;

        public async Task<IList<Lote>> GetAll()
        {
            return await _loteRepos.GetAll();
        }

        public async Task<Lote> GetById(int id)
        {
            return await _loteRepos.GetById(id);
        }

        public async Task<int> Insert(Lote obj)
        {
            return await _loteRepos.Insert(obj);
        }

        public async Task<bool> Update(Lote obj)
        {
            return await _loteRepos.Update(obj);
        }

        public async Task<bool> Delete(int id)
        {
            return await _loteRepos.Delete(id);
        }          
    }
}