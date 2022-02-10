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
    public class LoteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoteServ _loteServ;

        public LoteController(IMapper mapper, ILoteServ loteServ)
        {
            _mapper = mapper;
            _loteServ = loteServ;
        }

        /// <summary>
        /// Retorna todos os lotes
        /// </summary>
        /// <remarks>Returna todos os Lotes</remarks>
        [HttpGet]
        [Route("/v1/lote")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> GetLoteAsync()
        {
            try
            { 
                var result = _mapper.Map<List<LoteModel>>(await _loteServ.GetAll());
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
        /// Retorna lote por id
        /// </summary>
        /// <remarks>Returna um Lote por id</remarks>
        /// <param name="id">Retorna lote por id</param>
        [HttpGet]
        [Route("/v1/lote/{id}")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> GetLoteByIdAsync([FromRoute][Required] int id)
        {
            try
            {
                var result = _mapper.Map<LoteModel>(await _loteServ.GetById(id));
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
        /// Inclui novo lote
        /// </summary>
        /// <remarks>Inclui novo lote</remarks>
        /// <param name="body">Inclui novo lote</param>
        [HttpPost]
        [Route("/v1/lote")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> PostLoteAsync([FromBody] LoteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                    return new ObjectResult(await _loteServ.Insert(_mapper.Map<Lote>(model)));

                return new ObjectResult(StatusCodes.Status400BadRequest.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Altera o lote
        /// </summary>
        /// <remarks>Altera o lote</remarks>
        /// <param name="body">Altera o lote</param>
        [HttpPut]
        [Route("/v1/lote")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> PutLoteAsync([FromBody] LoteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _loteServ.GetById(model.Id) != null)                    
                        return new ObjectResult(await _loteServ.Update(_mapper.Map<Lote>(model)));                        
                      
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
        /// Apaga um lote
        /// </summary>
        /// <param name="id">Apaga um lote</param>
        [HttpDelete]
        [Route("/v1/lote/{id}")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> DeleteLoteAsync([FromRoute][Required] int id)
        {
            try
            {
                if (await _loteServ.GetById(id) != null)                
                    return new ObjectResult(await _loteServ.Delete(id));               

                return new ObjectResult(StatusCodes.Status404NotFound.ToString());                
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }
    }
}
