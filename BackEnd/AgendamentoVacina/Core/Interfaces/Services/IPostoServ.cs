using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IPostoServ
    {
        Task<IList<Posto>> GetAll();
        Task<IList<Posto>> GetListAvailable();
        Task<Posto> GetById(int id);
        Task<int> Insert(Posto obj);
        Task<bool> Update(Posto obj);
        Task<bool> Delete(int id);  
         
    }
}