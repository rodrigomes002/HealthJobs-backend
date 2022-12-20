using HealthJobs.Domain.Vagas.Interface;
using HealthJobs.Infra.Context;

namespace HealthJobs.Infra.Vagas
{
    public class VagaRepository : IVagaRepository
    {
        private readonly ApplicationContext context;

        public VagaRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}
