namespace HealthJobs.Infra.UoW
{
    public interface IUnitOfWork
    {
        void Commit();
        void Dispose();
    }
}
