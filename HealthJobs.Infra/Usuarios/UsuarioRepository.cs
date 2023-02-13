using HealthJobs.Domain.Usuarios;
using HealthJobs.Domain.Usuarios.Interface;
using HealthJobs.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthJobs.Infra.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext context;

        public UsuarioRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task Cadastrar(Usuario usuario)
        {
            await this.context.Usuarios.AddAsync(usuario);
        }

        public async Task<Usuario> ListarPorEmail(string email)
        {
            return await this.context.Usuarios.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Usuario> Verificar(string email, string senha)
        {
            return await this.context.Usuarios
                .Where(u => u.Email == email && u.Senha == senha)
                .FirstOrDefaultAsync();
        }
    }
}
