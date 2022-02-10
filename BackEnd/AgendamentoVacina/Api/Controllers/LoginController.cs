using System;
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
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioServ _usuarioServ;
        private readonly ITokenServ _tokenServ;

        public LoginController(IMapper mapper,
                               IUsuarioServ usuarioServ,
                               ITokenServ tokenServ)
        {
            _mapper = mapper;
            _usuarioServ = usuarioServ;
            _tokenServ = tokenServ;
        }

        /// <summary>
        /// Realiza login no sistema
        /// </summary>
        /// <remarks>Realiza login no sistema</remarks>
        /// <param name="model">Inclui novo usuario</param>
        [HttpPost]
        [Route("/v1/login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginModel>> PostLogin([FromBody] LoginModel model)
        {
            try
            {
                var obj = await _usuarioServ.Login(model.Email, model.Senha);
                if (obj != null)
                {
                    var usuario = _mapper.Map<UsuarioModel>(obj);
                    return new ObjectResult(new LoginModel(){
                        Email = model.Email,
                        Senha = null,
                        IdPerfil = usuario.IdPerfil,
                        IdPosto = usuario.IdPosto,
                        NomeUsuario = usuario.Nome,
                        Token = _tokenServ.GenerateToken(obj)
                    });
                }
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