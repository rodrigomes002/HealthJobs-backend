namespace HealthJobs.Domain.Vagas
{
    public class Vaga
    {
        public string Empresa { get; private set; }
        public string Cargo { get; private set; }
        public int Salario { get; private set; }
        public string Descricao { get; private set; }

        public Vaga(string empresa, string cargo, int salario, string descricao)
        {
            if (String.IsNullOrEmpty(empresa)) throw new ArgumentException("Empresa inválida!");
            if (String.IsNullOrEmpty(cargo)) throw new ArgumentException("Cargo inválido!");
            if (String.IsNullOrEmpty(descricao)) throw new ArgumentException("Descrição inválida!");
            
            this.Empresa = empresa;
            this.Cargo = cargo;
            this.Salario = salario;
            this.Descricao = descricao;
        }
    }
}