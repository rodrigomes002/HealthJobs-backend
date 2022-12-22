﻿using HealthJobs.Domain.Vagas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthJobs.Infra.Context
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Vaga>? Vaga { get; set; }
        public DbSet<Candidatura>? Candidatura { get; set; }
    }
}
