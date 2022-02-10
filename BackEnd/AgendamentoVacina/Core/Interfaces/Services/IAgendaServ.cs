using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IAgendaServ
    {
        Task<IList<Agenda>> GetAll();
        Task<Agenda> GetById(int id);
        Task<int> Insert(Agenda agenda);
        Task<bool> Update(Agenda agenda);
        Task<bool> Delete(int id);
    }
}