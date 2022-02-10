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
    public class GrupoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGrupoServ _grupoServ;

        public GrupoController(IMapper mapper, IGrupoServ grupoServ)
        {
            _mapper = mapper;
            _grupoServ = grupoServ;
        }

        /// <summary>
        /// Retorna todos os grupos
        /// </summary>
        /// <remarks>Returna todos os Grupos</remarks>
        [HttpGet]
        [Route("/v1/grupo")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetGrupoAsync()
        {
            try
            {
                var result = _mapper.Map<List<GrupoModel>>(await _grupoServ.GetAll());
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
        /// Retorna grupo por id
        /// </summary>
        /// <remarks>Returna um Grupo por id</remarks>
        /// <param name="id">Retorna grupo por id</param>
        [HttpGet]
        [Route("/v1/grupo/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetGrupoByIdAsync([FromRoute][Required] int id)
        {
            try
            {
                var result = _mapper.Map<GrupoModel>(await _grupoServ.GetById(id));
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
        /// Inclui novo grupo
        /// </summary>
        /// <remarks>Inclui novo grupo</remarks>
        /// <param name="body">Inclui novo grupo</param>
        [HttpPost]
        [Route("/v1/grupo")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PostGrupoAsync([FromBody] GrupoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                    return new ObjectResult(await _grupoServ.Insert(_mapper.Map<Grupo>(model)));

                return new ObjectResult(StatusCodes.Status400BadRequest.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Altera o grupo
        /// </summary>
        /// <remarks>Altera o grupo</remarks>
        /// <param name="body">Altera o grupo</param>
        [HttpPut]
        [Route("/v1/grupo")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PutGrupoAsync([FromBody] GrupoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _grupoServ.GetById(model.Id) != null)
                        return new ObjectResult(await _grupoServ.Update(_mapper.Map<Grupo>(model)));

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
        /// Apaga um grupo
        /// </summary>
        /// <param name="id">Apaga um grupo</param>
        [HttpDelete]
        [Route("/v1/grupo/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteGrupoAsync([FromRoute][Required] int id)
        {
            try
            {
                if (await _grupoServ.GetById(id) != null)
                    return new ObjectResult(await _grupoServ.Delete(id));

                return new ObjectResult(StatusCodes.Status404NotFound.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }


        /// <summary>
        /// Retorna grupo por idade
        /// </summary>
        /// <remarks>Returna um Grupo por idade</remarks>
        /// <param name="date">Retorna grupo por idade</param>
        [HttpGet]
        [Route("/v1/grupo/date/{date}")]
        [Authorize]
        public async Task<IActionResult> GetGrupoByAgeAsync([FromRoute][Required] string date)
        {
            try
            {
                if (!string.IsNullOrEmpty(date) && DateTime.TryParse(date, out DateTime dt))
                {
                    var result = _mapper.Map<List<GrupoModel>>(await _grupoServ.GetListByAge(dt));
                    if (result != null)
                        return new ObjectResult(result);
                    else
                        return new ObjectResult(StatusCodes.Status404NotFound.ToString());
                }
                else 
                {
                    return new ObjectResult(StatusCodes.Status400BadRequest.ToString());
                }
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }
    }
}
