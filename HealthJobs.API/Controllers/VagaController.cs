using HealthJobs.Application.Vagas.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthJobs.API.Controllers
{
    [ApiController]
    [Route("api/vaga")]
    public class VagaController : ControllerBase
    {
        private readonly ILogger<VagaController> _logger;
        private readonly IMediator _mediator;

        public VagaController(ILogger<VagaController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost, Route("cadastrar")]
        public IActionResult CadastrarVaga(CadastrarVagaCommand request)
        {
            _mediator.Send(request);
            return StatusCode(201);
        }

    }
}