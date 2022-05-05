using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enumerators;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class EstatisticaServ : IEstatisticaServ
    {
        private readonly IAgendamentoRepos _agendamentoRepos;
        private readonly ILoteRepos _loteRepos;

        public EstatisticaServ(IAgendamentoRepos agendamentoRepos, ILoteRepos loteRepos)
        {
            _agendamentoRepos = agendamentoRepos;
            _loteRepos = loteRepos;
        }

        public async Task<List<Estatistica>> GetEstatisticaByEstatisticaEnum(TipoEstatisticaEnum tipoEstatisticaEnum)
        {
            switch (tipoEstatisticaEnum)
            {
                case TipoEstatisticaEnum.AgendamentosHoje :
                    return await GetAgendamentosHoje();

                case TipoEstatisticaEnum.AgendamentosTurno :
                    return await GetAgendamentosTurno();

                case TipoEstatisticaEnum.AtendimentoPostos :
                    return await GetAtendimentoPostos();

                case TipoEstatisticaEnum.GruposVacinados :
                    return await GetGruposVacinados();

                case TipoEstatisticaEnum.UtilizacaoLotes :
                    return await GetUtilizacaoLotes();
            }

            return null; 
        }

        private async Task<List<Estatistica>> GetAgendamentosHoje()
        {
            return await _agendamentoRepos.GetAgendamentosHoje(); 
        }

        private async Task<List<Estatistica>> GetAgendamentosTurno()
        {
            return await _agendamentoRepos.GetAgendamentosTurno();
        }

        private async Task<List<Estatistica>>  GetAtendimentoPostos()
        {
            return await _agendamentoRepos.GetAtendimentoPostos();
        }

        private async Task<List<Estatistica>> GetUtilizacaoLotes()
        {
            return await _loteRepos.GetUtilizacaoLotes(); 
        }

        private async Task<List<Estatistica>> GetGruposVacinados()
        {
            return await _agendamentoRepos.GetGruposVacinados();
        }
    }
}