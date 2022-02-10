
using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Api.Models;
using AutoMapper;
using Core.Interfaces.Services;
using Core.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [ApiController]
    public class AgendamentoController : ControllerBase
    { 
        private readonly IMapper _mapper;
        private readonly IAgendamentoServ _agendamentoServ;

        public AgendamentoController(IMapper mapper, IAgendamentoServ agendamentoServ)
        {
            _mapper = mapper;
            _agendamentoServ = agendamentoServ;
        }

        /// <summary>
        /// Retorna agendamento por cpf
        /// </summary>
        /// <remarks>Returna um Agendamento por cpf</remarks>
        /// <param name="cpf">Retorna agendamento por cpf</param>
        [HttpGet]
        [Route("/v1/agendamento/{cpf}")]
        [Authorize]
        public async Task<IActionResult> GetByCpfAsync([FromRoute][Required]string cpf)
        { 
            try
            {
                return new ObjectResult(_mapper.Map<AgendamentoModel>(await _agendamentoServ.GetByCpf(cpf)));
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Inclui novo agendamento
        /// </summary>
        /// <remarks>Inclui novo agendamento de agendamento</remarks>
        /// <param name="body">Inclui novo agendamento</param>
        [HttpPost]
        [Route("/v1/agendamento")]
        [Authorize]
        public async Task<IActionResult> PostAgendamentoAsync([FromBody]AgendamentoModel model)
        { 
            try
            {
                return new ObjectResult(await _agendamentoServ.Insert(_mapper.Map<Agendamento>(model)));
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Altera o agendamento
        /// </summary>
        /// <remarks>Altera o agendamento do agendamento</remarks>
        /// <param name="body">Altera o agendamento</param>
        [HttpPut]
        [Route("/v1/agendamento")]
        [Authorize(Roles = "Recepcionista")]
        public async Task<IActionResult> PutAgendamentoAsync([FromBody]AgendamentoModel model)
        { 
            try
            {
                if (ModelState.IsValid)
                {
                    var ent = await _agendamentoServ.GetByCpf(model.DadosPessoais.Cpf.Replace(".","").Replace("-",""));
                    if (ent != null)
                    {
                        var obj = _mapper.Map<Agendamento>(model);
                        obj.IdEndereco = ent.IdEndereco;
                        return new ObjectResult(await _agendamentoServ.Update(obj));
                    }

                    return new ObjectResult(StatusCodes.Status404NotFound.ToString());
                }

                return new ObjectResult(StatusCodes.Status400BadRequest.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }
    }
}
