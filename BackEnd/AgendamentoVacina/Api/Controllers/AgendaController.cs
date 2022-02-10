using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Api.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAgendaServ _agendaServ;

        public AgendaController(IMapper mapper, IAgendaServ agendaServ)
        {
            _mapper = mapper;
            _agendaServ = agendaServ;
        }

        /// <summary>
        /// Retorna todos os agendas
        /// </summary>
        /// <remarks>Returna todos os Agendas</remarks>
        [HttpGet]
        [Route("/v1/agenda")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> GetAgendaAsync()
        {
            try
            {
                var result = _mapper.Map<List<AgendaModel>>(await _agendaServ.GetAll());
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
        /// Retorna agenda por id
        /// </summary>
        /// <remarks>Returna um Agenda por id</remarks>
        /// <param name="id">Retorna agenda por id</param>
        [HttpGet]
        [Route("/v1/agenda/{id}")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> GetAgendaByIdAsync([FromRoute][Required] int id)
        {
            try
            {
                var result = _mapper.Map<AgendaModel>(await _agendaServ.GetById(id));
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
        /// Inclui novo agenda
        /// </summary>
        /// <remarks>Inclui novo agenda</remarks>
        /// <param name="body">Inclui novo agenda</param>
        [HttpPost]
        [Route("/v1/agenda")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> PostAgendaAsync([FromBody] AgendaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                    return new ObjectResult(await _agendaServ.Insert(_mapper.Map<Agenda>(model)));

                return new ObjectResult(StatusCodes.Status400BadRequest.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Altera o agenda
        /// </summary>
        /// <remarks>Altera o agenda</remarks>
        /// <param name="body">Altera o agenda</param>
        [HttpPut]
        [Route("/v1/agenda")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> PutAgendaAsync([FromBody] AgendaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _agendaServ.GetById(model.Id) != null)                    
                        return new ObjectResult(await _agendaServ.Update(_mapper.Map<Agenda>(model)));                        
                      
                    return new ObjectResult(StatusCodes.Status404NotFound.ToString());
                }

                return new ObjectResult(StatusCodes.Status400BadRequest.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Apaga um agenda
        /// </summary>
        /// <param name="id">Apaga um agenda</param>
        [HttpDelete]
        [Route("/v1/agenda/{id}")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> DeleteAgendaAsync([FromRoute][Required] int id)
        {
            try
            {
                if (await _agendaServ.GetById(id) != null)                
                    return new ObjectResult(await _agendaServ.Delete(id));               

                return new ObjectResult(StatusCodes.Status404NotFound.ToString());                
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }
    }
}
