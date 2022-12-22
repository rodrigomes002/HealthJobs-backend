namespace HealthJobs.Domain.Vagas.Interface
{
    public interface IVagaRepository
    {
        void CadastrarAsync(Vaga vaga);
    }
}
