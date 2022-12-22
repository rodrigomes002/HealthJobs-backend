using HealthJobs.Infra.Context;

namespace HealthJobs.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext applicationContext;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public void Commit()
        {
            applicationContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            applicationContext.DisposeAsync();
        }
    }
}
