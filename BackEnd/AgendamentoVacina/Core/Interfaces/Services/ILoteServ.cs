using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface ILoteServ
    {
        Task<IList<Lote>> GetAll();
        Task<Lote> GetById(int id);
        Task<int> Insert(Lote Lote);
        Task<bool> Update(Lote Lote);
        Task<bool> Delete(int id);
    }
}