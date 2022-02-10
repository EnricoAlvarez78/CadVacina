using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Api.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [ApiController]
    public class PostoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPostoServ _postoServ;

        public PostoController(IMapper mapper, IPostoServ postoServ)
        {
            _mapper = mapper;
            _postoServ = postoServ;
        }

        /// <summary>
        /// Retorna todos os postos
        /// </summary>
        /// <remarks>Returna todos os Postos</remarks>
        [HttpGet]
        [Route("/v1/posto")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetPostoAsync()
        {
            try
            {
                var result = _mapper.Map<List<PostoModel>>(await _postoServ.GetAll());
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
        /// Retorna todos os postos
        /// </summary>
        /// <remarks>Returna todos os Postos</remarks>
        [HttpGet]
        [Route("/v1/posto/availables")]
        [Authorize]
        public async Task<IActionResult> GetPostoListAvailableAsync()
        {
            try
            {
                var result = _mapper.Map<List<PostoModel>>(await _postoServ.GetListAvailable());
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
        /// Retorna posto por id
        /// </summary>
        /// <remarks>Returna um Posto por id</remarks>
        /// <param name="id">Retorna posto por id</param>
        [HttpGet]
        [Route("/v1/posto/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetPostoByIdAsync([FromRoute][Required] int id)
        {
            try
            {
                var result = _mapper.Map<PostoModel>(await _postoServ.GetById(id));
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
        /// Inclui novo posto
        /// </summary>
        /// <remarks>Inclui novo posto</remarks>
        /// <param name="body">Inclui novo posto</param>
        [HttpPost]
        [Route("/v1/posto")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PostPostoAsync([FromBody] PostoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                    return new ObjectResult(await _postoServ.Insert(_mapper.Map<Posto>(model)));

                return new ObjectResult(StatusCodes.Status400BadRequest.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Altera o posto
        /// </summary>
        /// <remarks>Altera o posto</remarks>
        /// <param name="body">Altera o posto</param>
        [HttpPut]
        [Route("/v1/posto")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PutPostoAsync([FromBody] PostoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ent = await _postoServ.GetById(model.Id);
                    if (ent != null)
                    {
                        var obj = _mapper.Map<Posto>(model);
                        obj.IdEndereco = ent.IdEndereco;
                        return new ObjectResult(await _postoServ.Update(obj));
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

        /// <summary>
        /// Apaga um posto
        /// </summary>
        /// <param name="id">Apaga um posto</param>
        [HttpDelete]
        [Route("/v1/posto/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeletePostoAsync([FromRoute][Required] int id)
        {
            try
            {
                if (await _postoServ.GetById(id) != null)
                    return new ObjectResult(await _postoServ.Delete(id));

                return new ObjectResult(StatusCodes.Status404NotFound.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }
    }
}
