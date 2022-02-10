using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using AutoMapper;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackEnd.AgendamentoVacina.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerfilController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPerfilServ _perfilServ;

        public PerfilController(IMapper mapper, IPerfilServ perfilServ)
        {
            _mapper = mapper;
            _perfilServ = perfilServ;
        }

                /// <summary>
        /// Retorna todos os perfils
        /// </summary>
        /// <remarks>Returna todos os Perfils</remarks>
        [HttpGet]
        [Route("/v1/perfil")]
        [Authorize]
        public async Task<IActionResult> GetPerfilAsync()
        {
            try
            {
                var result = _mapper.Map<List<PerfilModel>>(await _perfilServ.GetAll());
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