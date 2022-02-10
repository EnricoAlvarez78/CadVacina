using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IPostoRepos
    {
        Task<IList<Posto>> GetAll();
        Task<Posto> GetById(int id);
        Task<int> Insert(Posto obj);
        Task<bool> Update(Posto obj);
        Task<bool> Delete(int id);         
    }
}