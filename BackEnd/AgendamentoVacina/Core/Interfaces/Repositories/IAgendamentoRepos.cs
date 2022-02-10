using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IAgendamentoRepos
    {
        Task<IList<Agendamento>> GetAll();
        Task<Agendamento> GetByCpf(string cpf);
        Task<int> Insert(Agendamento obj);
        Task<bool> Update(Agendamento obj);      
    }
}