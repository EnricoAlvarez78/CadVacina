using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ILoteRepos
    {
        Task<IList<Lote>> GetAll();
        Task<Lote> GetById(int id);
        Task<int> Insert(Lote obj);
        Task<bool> Update(Lote obj);
        Task<bool> Delete(int id);
        Task<List<Estatistica>>  GetUtilizacaoLotes();
    }
}