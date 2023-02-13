namespace HealthJobs.Domain.Usuarios
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; private set; } = DateTime.Now;
    }
}