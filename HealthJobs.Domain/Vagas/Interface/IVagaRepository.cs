using HealthJobs.Domain.Vagas.Filtro;

namespace HealthJobs.Domain.Vagas.Interface
{
    public interface IVagaRepository
    {
        Task CadastrarAsync(Vaga vaga);
        void Atualizar(Vaga vaga);
        Task<Vaga> ListarPorIdAsync(int id);
        Task<List<Vaga>> ListarAsync();
        Task<List<Vaga>> ListarPorFiltroAsync(VagaFiltro filtro);
        Task<int> Count(VagaFiltro filtro);
    }
}
