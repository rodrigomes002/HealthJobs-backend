using HealthJobs.Application.Vagas.Commands;
using HealthJobs.Domain.Vagas;
using HealthJobs.Domain.Vagas.Interface;
using HealthJobs.Infra.UoW;
using MediatR;

namespace HealthJobs.Application.Vagas.Handlers
{
    public class CadastrarVagaCommandHandler : IRequestHandler<CadastrarVagaCommand, bool>
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CadastrarVagaCommandHandler(IVagaRepository vagaRepository, IUnitOfWork unitOfWork)
        {
            this._vagaRepository = vagaRepository;
            this._unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(CadastrarVagaCommand request, CancellationToken cancellationToken)
        {
            var vaga = new Vaga(request.Empresa, request.Cargo, request.Salario, request.Descricao);

            _vagaRepository.CadastrarAsync(vaga);
            _unitOfWork.Commit();

            return Task.FromResult(true);
        }
    }
}
