using MediatR;

namespace HealthJobs.Application.Vagas.Commands
{
    public class CadastrarVagaCommand : IRequest<bool>
    {
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public int Salario { get; set; }
        public string Descricao { get; set; }
    }
}
