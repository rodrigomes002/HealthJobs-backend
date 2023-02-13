namespace HealthJobs.Domain.Usuarios.Interface
{
    public interface IUsuarioRepository
    {
        Task Cadastrar(Usuario usuario);
        Task<Usuario> ListarPorEmail(string email);
        Task<Usuario> Verificar(string email, string senha);
    }
}
