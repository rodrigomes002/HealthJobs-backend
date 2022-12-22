using HealthJobs.Application.Vagas.Commands;
using HealthJobs.Domain.Vagas;
using HealthJobs.Domain.Vagas.Interface;
using HealthJobs.Infra.UoW;

namespace HealthJobs.Application.Vagas.Handlers
{
    public class VagaService
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public VagaService(IVagaRepository vagaRepository, IUnitOfWork unitOfWork)
        {
            this._vagaRepository = vagaRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Vaga>> Listar()
        {
            return await _vagaRepository.ListarAsync();
        }

        public async Task Cadastrar(CadastrarVagaDTO request)
        {
            var vaga = new Vaga(request.Empresa, request.Cargo, request.Salario, request.Descricao);

            await _vagaRepository.CadastrarAsync(vaga);
            _unitOfWork.Commit();
        }

        public async Task Candidatar(CadastrarVagaDTO request)
        {
            var vaga = await _vagaRepository.ListarPorIdAsync(request.Id);
            var candidatura = new Candidatura(vaga, request.Candidato);
            vaga.InserirCandidatura(candidatura);

            _vagaRepository.Atualizar(vaga);
            _unitOfWork.Commit();
        }
    }
}
