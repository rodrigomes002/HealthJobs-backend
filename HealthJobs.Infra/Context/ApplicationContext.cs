using HealthJobs.Domain.Vagas;
using Microsoft.EntityFrameworkCore;

namespace HealthJobs.Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Vaga> Vaga { get; set; }
        public DbSet<Candidatura> Candidatura { get; set; }
    }
}
