using HealthJobs.Application.Autenticacao.DTOs;
using HealthJobs.Application.Autenticacao.Services;
using HealthJobs.Application.Usuarios.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthJobs.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<ActionResult> Cadastrar([FromBody] UsuarioDTO dto)
        {
            try
            {
                await this._usuarioService.Cadastrar(dto);
                return Ok("Usuário cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioToken>> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var usuario = await this._usuarioService.Login(dto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
