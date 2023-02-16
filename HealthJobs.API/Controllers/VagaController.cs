using HealthJobs.Application.Vagas.Commands;
using HealthJobs.Application.Vagas.Handlers;
using HealthJobs.Domain.Vagas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthJobs.API.Controllers
{
    [ApiController]
    [Route("api/vaga")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class VagaController : ControllerBase
    {
        private readonly ILogger<VagaController> _logger;
        private readonly VagaService _service;
        public VagaController(ILogger<VagaController> logger, VagaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet, Route("vagas")]        
        public async Task<List<Vaga>> ListarVagas()
        {
            try
            {
                return await _service.Listar();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        [HttpPost, Route("cadastrar")]
        [Authorize(Roles = "Empresa")]
        public async Task<IActionResult> CadastrarVaga([FromBody] CadastrarVagaDTO request)
        {
            try
            {
                await _service.Cadastrar(request);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        [HttpPost, Route("candidatar")]
        [Authorize(Roles = "Profissional")]
        public async Task<IActionResult> Candidatar([FromBody] CadastrarVagaDTO request)
        {
            try
            {
                await _service.Candidatar(request);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

    }
}