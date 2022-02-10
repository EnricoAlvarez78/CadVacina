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
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioServ _usuarioServ;

        public UsuarioController(IMapper mapper, IUsuarioServ usuarioServ)
        {
            _mapper = mapper;
            _usuarioServ = usuarioServ;
        }

        /// <summary>
        /// Retorna todos os usuarios
        /// </summary>
        /// <remarks>Returna todos os Usuarios</remarks>
        [HttpGet]
        [Route("/v1/usuario")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetUsuariosAsync()
        {
            try
            {
                var result = _mapper.Map<List<UsuarioModel>>(await _usuarioServ.GetAll());
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
        /// Retorna usuario por id
        /// </summary>
        /// <remarks>Returna um Usuario por id</remarks>
        /// <param name="id">Retorna usuario por id</param>
        [HttpGet]
        [Route("/v1/usuario/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetUsuarioByIdAsync([FromRoute][Required] int id)
        {
            try
            {
                var result = _mapper.Map<UsuarioModel>(await _usuarioServ.GetById(id));
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
        /// Inclui novo usuario
        /// </summary>
        /// <remarks>Inclui novo usuario</remarks>
        /// <param name="body">Inclui novo usuario</param>
        [HttpPost]
        [Route("/v1/usuario")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PostUsuarioAsync([FromBody] UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                    return new ObjectResult(await _usuarioServ.Insert(_mapper.Map<Usuario>(model)));

                return new ObjectResult(StatusCodes.Status400BadRequest.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Altera o usuario
        /// </summary>
        /// <remarks>Altera o usuario</remarks>
        /// <param name="body">Altera o usuario</param>
        [HttpPut]
        [Route("/v1/usuario")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PutUsuarioAsync([FromBody] UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ent = await _usuarioServ.GetById(model.Id);
                    if (ent != null)
                    {
                        var obj = _mapper.Map<Usuario>(model);
                        obj.Senha = ent.Senha;
                        return new ObjectResult(await _usuarioServ.Update(obj));
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
        /// Apaga um usuario
        /// </summary>
        /// <param name="id">Apaga um usuario</param>
        [HttpDelete]
        [Route("/v1/usuario/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteUsuarioAsync([FromRoute][Required] int id)
        {
            try
            {
                if (await _usuarioServ.GetById(id) != null)
                    return new ObjectResult(await _usuarioServ.Delete(id));

                return new ObjectResult(StatusCodes.Status404NotFound.ToString());
            }
            catch (Exception ex)
            {
                return new ObjectResult(JsonConvert.DeserializeObject<string>(ex.Message));
            }
        }

        /// <summary>
        /// Altera a senha do usuario
        /// </summary>
        /// <remarks>Altera a senha do usuario</remarks>
        /// <param name="body">Altera o usuario</param>
        [HttpPut]
        [Route("/v1/usuario/alterpassword")]
        [Authorize]
        public async Task<IActionResult> PutAlterPasswordAsync([FromBody] LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ent = await _usuarioServ.GetByEmail(model.Email);
                    if (ent != null)
                    {
                        ent.Senha = model.Senha;
                        return new ObjectResult(await _usuarioServ.UpdatePassword(ent));
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
        /// Reincia a senha do usuario
        /// </summary>
        /// <remarks>Reinicia a senha do usuario</remarks>
        /// <param name="body">Reinicia a senha do usuario</param>
        [HttpPut]
        [Route("/v1/usuario/resetpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> PutResetPasswordAsync([FromBody] EmailModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Email))
                {
                    var ent = await _usuarioServ.GetByEmail(model.Email);
                    if (ent != null)
                    {                     
                        return new ObjectResult(await _usuarioServ.ResetPassword(ent));
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
