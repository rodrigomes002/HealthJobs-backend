using HealthJobs.Domain.Usuarios;
using HealthJobs.Domain.Vagas;
using Microsoft.EntityFrameworkCore;

namespace HealthJobs.Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Vaga>? Vagas { get; set; }
        public DbSet<Candidatura>? Candidaturas { get; set; }
    }
}
