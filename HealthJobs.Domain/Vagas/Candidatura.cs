namespace HealthJobs.Domain.Vagas
{
    public class Candidatura
    {
        public int Id { get; set; }
        public Vaga Vaga { get; set; }
        public string Candidato { get; set; }

        public Candidatura(Vaga vaga, string candidato)
        {
            if (String.IsNullOrEmpty(candidato)) throw new ArgumentException("Candidato inválido!");

            Vaga = vaga;
            Candidato = candidato;
        }
    }
}
