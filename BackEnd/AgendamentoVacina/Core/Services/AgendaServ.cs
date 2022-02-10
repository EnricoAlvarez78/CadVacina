using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class AgendaServ : IAgendaServ
    {
        private readonly IAgendaRepos _agendaRepos;

        public AgendaServ(IAgendaRepos agendaRepos) => _agendaRepos = agendaRepos;

        public async Task<IList<Agenda>> GetAll()
        {
            return await _agendaRepos.GetAll();
        }

        public async Task<Agenda> GetById(int id)
        {
            return await _agendaRepos.GetById(id);
        }

        public async Task<int> Insert(Agenda agenda)
        {
            return await _agendaRepos.Insert(agenda);
        }

        public async Task<bool> Update(Agenda agenda)
        {
            return await _agendaRepos.Update(agenda);
        }

        public async Task<bool> Delete(int id)
        {
            return await _agendaRepos.Delete(id);
        }
    }
}