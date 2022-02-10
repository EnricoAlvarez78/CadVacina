using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class AgendamentoServ : IAgendamentoServ
    {
        private readonly IAgendamentoRepos _agendamentoRepos;

        public AgendamentoServ(IAgendamentoRepos agendamentoRepos) => _agendamentoRepos = agendamentoRepos;

        public async Task<IList<Agendamento>> GetAll()
        {
            return await _agendamentoRepos.GetAll();
        }

        public async Task<Agendamento> GetByCpf(string cpf)
        {
            return await _agendamentoRepos.GetByCpf(cpf);
        }

        public async Task<int> Insert(Agendamento obj)
        {
            return await _agendamentoRepos.Insert(obj);
        }

        public async Task<bool> Update(Agendamento obj)
        {
            return await _agendamentoRepos.Update(obj);
        }  
    }
}