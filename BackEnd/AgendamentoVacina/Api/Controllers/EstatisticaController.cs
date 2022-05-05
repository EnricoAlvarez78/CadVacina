using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using AutoMapper;
using Core.Enumerators;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [ApiController]
    public class EstatisticaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEstatisticaServ _estatisticaServ;

        public EstatisticaController(IMapper mapper, IEstatisticaServ estatisticaServ)
        {
            _mapper = mapper;
            _estatisticaServ = estatisticaServ;
        }

        /// <summary>
        /// Retorna lista de estatisticas de Atendimento nos Postos
        /// </summary>
        /// <remarks>Retorna de lista estatisticas de Atendimento nos Postos</remarks>
        [HttpGet]
        [Route("/v1/estatistica/atendimentopostos")]
        [Authorize]
        public async Task<IActionResult> GetAtendimentoPostos()
        { 
            try
            {
                var result =  _mapper.Map<List<EstatisticaModel>>(await _estatisticaServ.GetEstatisticaByEstatisticaEnum(TipoEstatisticaEnum.AtendimentoPostos));
                if (result != null)
                    return new ObjectResult(result);
                else
                    return new ObjectResult(StatusCodes.Status404NotFound.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Retorna lista de estatisticas de Agendamentos Hoje
        /// </summary>
        /// <remarks>Retorna lista de estatisticas de Agendamentos Hoje</remarks>
        [HttpGet]
        [Route("/v1/estatistica/agendamentoshoje")]
        [Authorize]
        public async Task<IActionResult> GetAgendamentosHoje()
        { 
            try
            {
                var result =  _mapper.Map<List<EstatisticaModel>>(await _estatisticaServ.GetEstatisticaByEstatisticaEnum(TipoEstatisticaEnum.AgendamentosHoje));
                if (result != null)
                    return new ObjectResult(result);
                else
                    return new ObjectResult(StatusCodes.Status404NotFound.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Retorna lista de estatisticas de Agendamentos por Turno
        /// </summary>
        /// <remarks>Retorna lista de estatisticas de Agendamentos por Turno</remarks>
        [HttpGet]
        [Route("/v1/estatistica/agendamentosturno")]
        [Authorize]
        public async Task<IActionResult> GetAgendamentosTurno()
        { 
            try
            {
                var result =  _mapper.Map<List<EstatisticaModel>>(await _estatisticaServ.GetEstatisticaByEstatisticaEnum(TipoEstatisticaEnum.AgendamentosTurno));
                if (result != null)
                    return new ObjectResult(result);
                else
                    return new ObjectResult(StatusCodes.Status404NotFound.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Retorna lista de estatisticas de Grupos de Vacinados
        /// </summary>
        /// <remarks>Retorna lista de estatisticas de Atendimento nos Postos</remarks>
        [HttpGet]
        [Route("/v1/estatistica/gruposvacinados")]
        [Authorize]
        public async Task<IActionResult> GetGruposVacinados()
        { 
            try
            {
                var result =  _mapper.Map<List<EstatisticaModel>>(await _estatisticaServ.GetEstatisticaByEstatisticaEnum(TipoEstatisticaEnum.GruposVacinados));
                if (result != null)
                    return new ObjectResult(result);
                else
                    return new ObjectResult(StatusCodes.Status404NotFound.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Retorna lista de estatisticas de Utilização dos Lotes
        /// </summary>
        /// <remarks>Retorna lista de estatisticas de Utilização dos Lotes</remarks>
        [HttpGet]
        [Route("/v1/estatistica/utilizacaolotes")]
        [Authorize]
        public async Task<IActionResult> GetUtilizacaoLotes()
        { 
            try
            {
                var result =  _mapper.Map<List<EstatisticaModel>>(await _estatisticaServ.GetEstatisticaByEstatisticaEnum(TipoEstatisticaEnum.UtilizacaoLotes));
                if (result != null)
                    return new ObjectResult(result);
                else
                    return new ObjectResult(StatusCodes.Status404NotFound.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }
    }
}