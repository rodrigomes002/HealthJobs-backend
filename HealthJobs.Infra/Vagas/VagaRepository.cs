using HealthJobs.Domain.Vagas;
using HealthJobs.Domain.Vagas.Interface;
using HealthJobs.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthJobs.Infra.Vagas
{
    public class VagaRepository : IVagaRepository
    {
        private readonly ApplicationContext _context;

        public VagaRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public void Atualizar(Vaga vaga)
        {
           _context.Vaga.Update(vaga);
        }

        public async Task CadastrarAsync(Vaga vaga)
        {
            await _context.Vaga.AddAsync(vaga);
        }

        public async Task<List<Vaga>> ListarAsync()
        {
            return await _context.Vaga
                .Include(c=> c.Candidaturas)
                .ToListAsync();
        }

        public async Task<Vaga> ListarPorIdAsync(int id)
        {
            return await _context.Vaga.Where(v => v.Id == id).FirstOrDefaultAsync();
        }
    }
}
