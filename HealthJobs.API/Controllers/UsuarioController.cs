using HealthJobs.Application.Autenticacao.DTOs;
using HealthJobs.Application.Autenticacao.Services;
using HealthJobs.Application.Usuarios.DTOs;
using HealthJobs.Application.Usuarios.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthJobs.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly IConfiguration _configuration;
        public UsuarioController(UsuarioService usuarioService, IConfiguration configuration)
        {
            this._usuarioService = usuarioService;
            this._configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioDTO dto)
        {
            var result = await this._usuarioService.Cadastrar(dto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var result = await this._usuarioService.Login(dto);

            if (!result.Succeeded)
                return BadRequest();

            return Ok(new JwtService(_configuration).GeraToken(dto));

        }
    }
}
