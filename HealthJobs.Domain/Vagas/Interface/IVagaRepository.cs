namespace HealthJobs.Domain.Vagas.Interface
{
    public interface IVagaRepository
    {
        Task CadastrarAsync(Vaga vaga);
        void Atualizar(Vaga vaga);
        Task<Vaga> ListarPorIdAsync(int id);
        Task<List<Vaga>> ListarAsync();
    }
}
